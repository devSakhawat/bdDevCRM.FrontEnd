using bdDevCRM.FrontEnd.Context;
using bdDevCRM.FrontEnd.Models.Menu;
using Microsoft.EntityFrameworkCore;

namespace bdDevCRM.FrontEnd.Services;

public class MenuService : IMenuService
{
	private readonly CRMContext _context;

	// ── DI Constructor ────────────────────────────────────────────────
	// CRMContext inject হয় Program.cs-এর DI container থেকে।
	public MenuService(CRMContext context)
	{
		_context = context;
	}

	// ════════════════════════════════════════════════════════════════
	// PUBLIC METHOD: GetMenuByUserIdAsync
	// ════════════════════════════════════════════════════════════════
	public async Task<List<SidebarMenuItemDto>> GetMenuByUserIdAsync(int userId)
	{
		// ── ধাপ ১: Raw SQL execute করে flat list আনো ─────────────────
		var flatList = await ExecuteMenuQueryAsync(userId);

		// ── ধাপ ২: Flat list কে nested tree-তে convert করো ──────────
		var tree = BuildMenuTree(flatList);

		return tree;
	}

	// ════════════════════════════════════════════════════════════════
	// PRIVATE: Raw SQL Execute
	// ════════════════════════════════════════════════════════════════
	private async Task<List<MenuQueryDto>> ExecuteMenuQueryAsync(int userId)
	{
		// ── আপনার original SQL query (parameterized) ──────────────────
		// {0} placeholder-এ userId inject হয় — SQL injection safe।
		// EF Core internally এটাকে parameterized query-তে convert করে।
		const string sql = @"
                SELECT DISTINCT
                    Menu.MenuId,
                    Menu.ModuleId,
                    GroupMember.UserId,
                    GroupPermission.PermissionTableName,
                    Menu.MenuName,
                    Menu.MenuPath,
                    Menu.ParentMenu,
                    Menu.Sororder,
                    Menu.ToDo
                FROM GroupMember
                    INNER JOIN Groups
                        ON GroupMember.GroupId = Groups.GroupId
                    INNER JOIN GroupPermission
                        ON Groups.GroupId = GroupPermission.GroupId
                    INNER JOIN Menu
                        ON GroupPermission.ReferenceID = Menu.MenuId
                WHERE
                    (GroupMember.UserId = 1)
                    AND (GroupPermission.PermissionTableName = 'Menu')
                ORDER BY
                    Menu.Sororder,
                    Menu.MenuName";

		// ── EF Core Raw SQL Execution ─────────────────────────────────
		// FromSqlRaw() → SQL execute করে
		// AsNoTracking() → শুধু read, DB change tracking বন্ধ (performance ভালো)
		// ToListAsync() → async-এ result fetch করে
		//
		// গুরুত্বপূর্ণ: MenuQueryDto কে DbSet হিসেবে register করতে হবে
		// CRMContext-এ। নিচে দেখুন কীভাবে করতে হবে।
		var results = await _context.MenuQueryResults
																.FromSqlRaw(sql, userId)
																.AsNoTracking()
																.ToListAsync();

		return results;
	}

	// ════════════════════════════════════════════════════════════════
	// PRIVATE: Flat List → Nested Tree
	//
	// ব্যাখ্যা:
	// SQL থেকে আসা flat list-এ সব menu একই level-এ থাকে।
	// ParentMenu column দেখে বোঝা যায় কোনটা কার child।
	//
	// Algorithm:
	// ১. প্রথমে সব item কে SidebarMenuItemDto-তে map করো।
	// ২. একটা Dictionary<int, SidebarMenuItemDto> তৈরি করো (key = MenuId)।
	// ৩. প্রতিটা item-এর ParentMenu check করো:
	//    - null হলে → root list-এ যোগ করো
	//    - non-null হলে → সেই parent-এর Children list-এ যোগ করো
	// ════════════════════════════════════════════════════════════════
	private static List<SidebarMenuItemDto> BuildMenuTree(List<MenuQueryDto> flatList)
	{
		// ── সব item কে DTO-তে map করো ────────────────────────────────
		var allItems = flatList.Select(m => new SidebarMenuItemDto
		{
			Id = $"menu-{m.MenuId}",
			Label = m.MenuName,
			Icon = ResolveIcon(m.MenuName, m.ModuleId),
			Url = string.IsNullOrWhiteSpace(m.MenuPath) ? null : m.MenuPath,
			Badge = (m.Todo.HasValue && m.Todo > 0) ? m.Todo.ToString() : null,
			Order = m.Sororder ?? 999,
			Section = null,        // পরে root items-এর জন্য assign হবে
			Children = new List<SidebarMenuItemDto>(),
			RawMenuId = m.MenuId,
			RawParentMenuId = m.ParentMenu
		}).ToList();

		// ── Dictionary তৈরি করো (MenuId → DTO) ───────────────────────
		// এতে parent খোঁজা O(1) time-এ হয়।
		var lookup = allItems.ToDictionary(x => x.RawMenuId);

		// ── Root items collect করার জন্য list ────────────────────────
		var rootItems = new List<SidebarMenuItemDto>();

		foreach (var item in allItems.OrderBy(x => x.Order))
		{
			if (item.RawParentMenuId == null)
			{
				// ── Root item → Section assign করো ───────────────────
				item.Section = ResolveSection(item.Label, item.RawMenuId, allItems);
				rootItems.Add(item);
			}
			else
			{
				// ── Child item → parent-এর Children list-এ যোগ করো ──
				if (lookup.TryGetValue(item.RawParentMenuId.Value, out var parent))
				{
					parent.Children ??= new List<SidebarMenuItemDto>();
					parent.Children.Add(item);
				}
				else
				{
					// Parent টা user-এর permission-এ নেই কিন্তু child আছে —
					// এক্ষেত্রে child কে root-এ রাখো।
					rootItems.Add(item);
				}
			}
		}

		// ── Empty Children list null করো (JSON size ছোট রাখতে) ───────
		CleanEmptyChildren(rootItems);

		return rootItems;
	}

	private static void CleanEmptyChildren(List<SidebarMenuItemDto> items)
	{
		foreach (var item in items)
		{
			if (item.Children != null)
			{
				if (item.Children.Count == 0)
					item.Children = null;
				else
					CleanEmptyChildren(item.Children);
			}
		}
	}

	// ════════════════════════════════════════════════════════════════
	// PRIVATE: Icon Resolver
	//
	// ব্যাখ্যা:
	// DB-তে icon store নেই, তাই MenuName এবং ModuleId দেখে
	// Font Awesome class assign করা হয়।
	// আপনি এখানে নিজের project অনুযায়ী icons যোগ করুন।
	// ════════════════════════════════════════════════════════════════
	private static string ResolveIcon(string menuName, int moduleId)
	{
		// ── MenuName দেখে exact match ─────────────────────────────────
		var nameMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
						{
                // Dashboard
                { "dashboard",          "fa-solid fa-gauge-high" },
								{ "home",               "fa-solid fa-house" },

                // CRM
                { "crm",                "fa-solid fa-briefcase" },
								{ "contacts",           "fa-solid fa-address-book" },
								{ "leads",              "fa-solid fa-funnel-dollar" },
								{ "accounts",           "fa-solid fa-building" },
								{ "opportunities",      "fa-solid fa-handshake" },
								{ "activities",         "fa-solid fa-calendar-check" },
								{ "pipeline",           "fa-solid fa-chart-gantt" },
								{ "customers",          "fa-solid fa-users" },
								{ "deals",              "fa-solid fa-tags" },
								{ "quotations",         "fa-solid fa-file-invoice" },

                // HR
                { "human resources",    "fa-solid fa-users" },
								{ "hr",                 "fa-solid fa-users" },
								{ "employees",          "fa-solid fa-user-tie" },
								{ "departments",        "fa-solid fa-sitemap" },
								{ "designations",       "fa-solid fa-id-badge" },
								{ "leave management",   "fa-solid fa-calendar-xmark" },
								{ "leave",              "fa-solid fa-calendar-xmark" },
								{ "leave types",        "fa-solid fa-tags" },
								{ "leave requests",     "fa-solid fa-inbox" },
								{ "leave balance",      "fa-solid fa-scale-balanced" },
								{ "onboarding",         "fa-solid fa-user-plus" },
								{ "documents",          "fa-solid fa-folder-open" },
								{ "training",           "fa-solid fa-graduation-cap" },
								{ "recruitment",        "fa-solid fa-magnifying-glass-plus" },

                // Payroll
                { "payroll",            "fa-solid fa-money-bill-wave" },
								{ "salary",             "fa-solid fa-wallet" },
								{ "salary structure",   "fa-solid fa-layer-group" },
								{ "pay slips",          "fa-solid fa-file-invoice-dollar" },
								{ "deductions",         "fa-solid fa-minus-circle" },
								{ "allowances",         "fa-solid fa-plus-circle" },
								{ "tax",                "fa-solid fa-percent" },
								{ "tax setup",          "fa-solid fa-percent" },
								{ "process payroll",    "fa-solid fa-play-circle" },
								{ "bonus",              "fa-solid fa-gift" },

                // Attendance
                { "attendance",         "fa-solid fa-clock" },
								{ "daily attendance",   "fa-solid fa-calendar-day" },
								{ "monthly report",     "fa-solid fa-calendar-alt" },
								{ "shift management",   "fa-solid fa-rotate" },
								{ "shifts",             "fa-solid fa-rotate" },
								{ "overtime",           "fa-solid fa-hourglass-half" },
								{ "holidays",           "fa-solid fa-umbrella-beach" },

                // Reports
                { "reports",            "fa-solid fa-chart-bar" },
								{ "crm reports",        "fa-solid fa-chart-line" },
								{ "hr reports",         "fa-solid fa-chart-pie" },
								{ "payroll reports",    "fa-solid fa-receipt" },
								{ "attendance reports", "fa-solid fa-table" },
								{ "analytics",          "fa-solid fa-chart-mixed" },

                // Administration
                { "administration",     "fa-solid fa-shield-halved" },
								{ "admin",              "fa-solid fa-shield-halved" },
								{ "users",              "fa-solid fa-users-gear" },
								{ "roles",              "fa-solid fa-user-lock" },
								{ "permissions",        "fa-solid fa-key" },
								{ "settings",           "fa-solid fa-sliders" },
								{ "audit logs",         "fa-solid fa-scroll" },
								{ "backup",             "fa-solid fa-database" },
								{ "configuration",      "fa-solid fa-gear" },
						};

		if (nameMap.TryGetValue(menuName.Trim(), out var icon))
			return icon;

		// ── ModuleId দেখে fallback ────────────────────────────────────
		return moduleId switch
		{
			1 => "fa-solid fa-briefcase",       // CRM
			2 => "fa-solid fa-users",            // HR
			3 => "fa-solid fa-money-bill-wave",  // Payroll
			4 => "fa-solid fa-clock",            // Attendance
			5 => "fa-solid fa-chart-bar",        // Reports
			9 => "fa-solid fa-shield-halved",    // Admin
			_ => "fa-solid fa-circle-dot"        // Default
		};
	}

	// ════════════════════════════════════════════════════════════════
	// PRIVATE: Section Resolver
	// Root item-গুলোকে visual group-এ ভাগ করে।
	// ════════════════════════════════════════════════════════════════
	private static string? ResolveSection(string menuName, int menuId, List<SidebarMenuItemDto> allItems)
	{
		var sectionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
						{
								{ "dashboard",       "Overview" },
								{ "home",            "Overview" },
								{ "crm",             "Business" },
								{ "human resources", "HR & Payroll" },
								{ "hr",              "HR & Payroll" },
								{ "payroll",         "HR & Payroll" },
								{ "attendance",      "HR & Payroll" },
								{ "reports",         "Analytics" },
								{ "analytics",       "Analytics" },
								{ "administration",  "System" },
								{ "admin",           "System" },
								{ "settings",        "System" },
						};

		if (sectionMap.TryGetValue(menuName.Trim(), out var section))
			return section;

		return null; // Section না থাকলে divider দেখাবে না
	}



	public Task<List<MenuItemDto>> GetMenuForUserAsync(string userId, List<string> roles)
	{
		bool isAdmin = roles.Contains("SuperAdmin") || roles.Contains("Admin");
		bool hasCrm = isAdmin || roles.Contains("CRM");
		bool hasHr = isAdmin || roles.Contains("HR");
		bool hasPayroll = isAdmin || roles.Contains("Payroll");
		bool hasAttend = isAdmin || roles.Contains("Attendance");
		bool hasReports = isAdmin || roles.Contains("Reports");

		var menu = new List<MenuItemDto>
		{
			new()
			{
				Id = "dashboard",
				Label = "Dashboard",
				Icon = "fa-solid fa-gauge-high",
				Section = "Overview",
				Url = "/Dashboard/Index",
				Permission = true,
				Order = 1
			},

			new()
			{
				Id = "crm",
				Label = "CRM",
				Icon = "fa-solid fa-briefcase",
				Section = "Business",
				Permission = hasCrm,
				Order = 10,
				Children = new()
				{
					new()
					{
						Id = "crm-contacts",
						Label = "Contacts",
						Icon = "fa-solid fa-address-book",
						Permission = hasCrm,
						Order = 1,
						Children = new()
						{
							new() { Id = "crm-contacts-list", Label = "All Contacts", Icon = "fa-solid fa-list", Url = "/CRM/Contacts/Index", Permission = hasCrm, Order = 1 },
							new() { Id = "crm-contacts-add", Label = "Add Contact", Icon = "fa-solid fa-plus", Url = "/CRM/Contacts/Create", Permission = hasCrm, Order = 2 },
							new() { Id = "crm-contacts-import", Label = "Import", Icon = "fa-solid fa-file-import", Url = "/CRM/Contacts/Import", Permission = isAdmin, Order = 3 }
						}
					},
					new()
					{
						Id = "crm-leads",
						Label = "Leads",
						Icon = "fa-solid fa-funnel-dollar",
						Badge = "8",
						Permission = hasCrm,
						Order = 2,
						Children = new()
						{
							new() { Id = "crm-leads-list", Label = "All Leads", Icon = "fa-solid fa-list", Url = "/CRM/Leads/Index", Permission = hasCrm, Order = 1 },
							new() { Id = "crm-leads-add", Label = "Add Lead", Icon = "fa-solid fa-plus", Url = "/CRM/Leads/Create", Permission = hasCrm, Order = 2 },
							new() { Id = "crm-leads-kanban", Label = "Kanban Board", Icon = "fa-solid fa-table-columns", Url = "/CRM/Leads/Kanban", Permission = hasCrm, Order = 3 }
						}
					},
					new()
					{
						Id = "crm-accounts",
						Label = "Accounts",
						Icon = "fa-solid fa-building",
						Permission = hasCrm,
						Order = 3,
						Children = new()
						{
							new() { Id = "crm-accounts-list", Label = "All Accounts", Icon = "fa-solid fa-list", Url = "/CRM/Accounts/Index", Permission = hasCrm, Order = 1 },
							new() { Id = "crm-accounts-add", Label = "Add Account", Icon = "fa-solid fa-plus", Url = "/CRM/Accounts/Create", Permission = hasCrm, Order = 2 }
						}
					},
					new() { Id = "crm-activities", Label = "Activities", Icon = "fa-solid fa-calendar-check", Url = "/CRM/Activities/Index", Permission = hasCrm, Order = 4 },
					new() { Id = "crm-pipeline", Label = "Sales Pipeline", Icon = "fa-solid fa-chart-gantt", Url = "/CRM/Pipeline/Index", Permission = hasCrm, Order = 5 }
				}
			},

			new()
			{
				Id = "hr",
				Label = "Human Resources",
				Icon = "fa-solid fa-users",
				Section = "HR & Payroll",
				Permission = hasHr,
				Order = 20,
				Children = new()
				{
					new() { Id = "hr-employees", Label = "Employees", Icon = "fa-solid fa-user-tie", Url = "/HR/Employees/Index", Permission = hasHr, Order = 1 },
					new() { Id = "hr-departments", Label = "Departments", Icon = "fa-solid fa-sitemap", Url = "/HR/Departments/Index", Permission = hasHr, Order = 2 },
					new() { Id = "hr-designations", Label = "Designations", Icon = "fa-solid fa-id-badge", Url = "/HR/Designations/Index", Permission = hasHr, Order = 3 },
					new()
					{
						Id = "hr-leave",
						Label = "Leave Management",
						Icon = "fa-solid fa-calendar-xmark",
						Permission = hasHr,
						Order = 4,
						Children = new()
						{
							new() { Id = "hr-leave-types", Label = "Leave Types", Icon = "fa-solid fa-tags", Url = "/HR/Leave/Types", Permission = hasHr, Order = 1 },
							new() { Id = "hr-leave-requests", Label = "Leave Requests", Icon = "fa-solid fa-inbox", Url = "/HR/Leave/Requests", Permission = hasHr, Order = 2, Badge = "3" },
							new() { Id = "hr-leave-balance", Label = "Leave Balance", Icon = "fa-solid fa-scale-balanced", Url = "/HR/Leave/Balance", Permission = hasHr, Order = 3 }
						}
					},
					new() { Id = "hr-onboarding", Label = "Onboarding", Icon = "fa-solid fa-user-plus", Url = "/HR/Onboarding/Index", Permission = isAdmin, Order = 5 },
					new() { Id = "hr-documents", Label = "Documents", Icon = "fa-solid fa-folder-open", Url = "/HR/Documents/Index", Permission = hasHr, Order = 6 }
				}
			},

			new()
			{
				Id = "payroll",
				Label = "Payroll",
				Icon = "fa-solid fa-money-bill-wave",
				Permission = hasPayroll,
				Order = 30,
				Children = new()
				{
					new() { Id = "payroll-process", Label = "Process Payroll", Icon = "fa-solid fa-play-circle", Url = "/Payroll/Process", Permission = isAdmin, Order = 1 },
					new() { Id = "payroll-slips", Label = "Pay Slips", Icon = "fa-solid fa-file-invoice", Url = "/Payroll/Slips/Index", Permission = hasPayroll, Order = 2 },
					new() { Id = "payroll-salary", Label = "Salary Structure", Icon = "fa-solid fa-layer-group", Url = "/Payroll/Salary/Index", Permission = isAdmin, Order = 3 },
					new() { Id = "payroll-deductions", Label = "Deductions", Icon = "fa-solid fa-minus-circle", Url = "/Payroll/Deductions", Permission = isAdmin, Order = 4 },
					new() { Id = "payroll-tax", Label = "Tax Setup", Icon = "fa-solid fa-percent", Url = "/Payroll/Tax", Permission = isAdmin, Order = 5 }
				}
			},

			new()
			{
				Id = "attendance",
				Label = "Attendance",
				Icon = "fa-solid fa-clock",
				Permission = hasAttend,
				Order = 40,
				Children = new()
				{
					new() { Id = "attend-daily", Label = "Daily Attendance", Icon = "fa-solid fa-calendar-day", Url = "/Attendance/Daily", Permission = hasAttend, Order = 1 },
					new() { Id = "attend-monthly", Label = "Monthly Report", Icon = "fa-solid fa-calendar-alt", Url = "/Attendance/Monthly", Permission = hasAttend, Order = 2 },
					new() { Id = "attend-shifts", Label = "Shift Management", Icon = "fa-solid fa-rotate", Url = "/Attendance/Shifts", Permission = isAdmin, Order = 3 },
					new() { Id = "attend-overtime", Label = "Overtime", Icon = "fa-solid fa-hourglass-half", Url = "/Attendance/Overtime", Permission = hasAttend, Order = 4 }
				}
			},

			new()
			{
				Id = "reports",
				Label = "Reports",
				Icon = "fa-solid fa-chart-bar",
				Section = "Analytics",
				Permission = hasReports,
				Order = 50,
				Children = new()
				{
					new() { Id = "reports-crm", Label = "CRM Reports", Icon = "fa-solid fa-chart-line", Url = "/Reports/CRM", Permission = hasReports && hasCrm, Order = 1 },
					new() { Id = "reports-hr", Label = "HR Reports", Icon = "fa-solid fa-chart-pie", Url = "/Reports/HR", Permission = hasReports && hasHr, Order = 2 },
					new() { Id = "reports-payroll", Label = "Payroll Reports", Icon = "fa-solid fa-receipt", Url = "/Reports/Payroll", Permission = hasReports && hasPayroll, Order = 3 },
					new() { Id = "reports-attend", Label = "Attendance Reports", Icon = "fa-solid fa-table", Url = "/Reports/Attendance", Permission = hasReports && hasAttend, Order = 4 }
				}
			},

			new()
			{
				Id = "admin",
				Label = "Administration",
				Icon = "fa-solid fa-shield-halved",
				Section = "System",
				Permission = isAdmin,
				Order = 90,
				Children = new()
				{
					new() { Id = "admin-users", Label = "Users", Icon = "fa-solid fa-users-gear", Url = "/Admin/Users", Permission = isAdmin, Order = 1 },
					new() { Id = "admin-roles", Label = "Roles", Icon = "fa-solid fa-user-lock", Url = "/Admin/Roles", Permission = isAdmin, Order = 2 },
					new() { Id = "admin-settings", Label = "Settings", Icon = "fa-solid fa-sliders", Url = "/Admin/Settings", Permission = isAdmin, Order = 3 },
					new() { Id = "admin-audit", Label = "Audit Logs", Icon = "fa-solid fa-scroll", Url = "/Admin/AuditLogs", Permission = isAdmin, Order = 4 },
					new() { Id = "admin-backup", Label = "Backup", Icon = "fa-solid fa-database", Url = "/Admin/Backup", Permission = isAdmin, Order = 5 }
				}
			}
		};

		return Task.FromResult(FilterMenu(menu));
	}

	private static List<MenuItemDto> FilterMenu(List<MenuItemDto> items)
	{
		var result = new List<MenuItemDto>();
		foreach (var item in items.Where(i => i.Permission).OrderBy(i => i.Order))
		{
			if (item.Children is { Count: > 0 })
			{
				item.Children = FilterMenu(item.Children);
			}

			result.Add(item);
		}

		return result;
	}
}
