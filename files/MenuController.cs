using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EnterpriseSuite.Controllers.Api
{
    /// <summary>
    /// Returns the dynamic sidebar menu based on the current user's roles/permissions.
    /// GET /api/menu
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Returns the full menu tree filtered by the current user's permissions.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetMenu()
        {
            var userId   = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var roles    = User.Claims
                               .Where(c => c.Type == ClaimTypes.Role)
                               .Select(c => c.Value)
                               .ToList();

            var menu = await _menuService.GetMenuForUserAsync(userId, roles);
            return Ok(menu);
        }
    }
}

/* ═══════════════════════════════════════════════════════════
   MODELS
═══════════════════════════════════════════════════════════ */
namespace EnterpriseSuite.Models.Menu
{
    /// <summary>One node in the sidebar navigation tree.</summary>
    public class MenuItemDto
    {
        /// <summary>Unique identifier used for active-state tracking in JS.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Display label in the sidebar.</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>Font Awesome class string, e.g. "fa-solid fa-briefcase".</summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>Section divider label (optional). Groups items visually.</summary>
        public string? Section { get; set; }

        /// <summary>
        /// The URL to load via fetch() into the main content area.
        /// Null/empty if this item has children (acts as accordion parent).
        /// </summary>
        public string? Url { get; set; }

        /// <summary>Optional badge text displayed next to the label (e.g. "12", "New").</summary>
        public string? Badge { get; set; }

        /// <summary>
        /// Whether the current user has permission to see this item.
        /// Items where Permission=false are filtered out by the service and never sent.
        /// This flag exists for completeness/logging.
        /// </summary>
        public bool Permission { get; set; } = true;

        /// <summary>Sort order within parent.</summary>
        public int Order { get; set; }

        /// <summary>Nested children (Level 2 and Level 3).</summary>
        public List<MenuItemDto>? Children { get; set; }
    }
}

/* ═══════════════════════════════════════════════════════════
   SERVICE INTERFACE
═══════════════════════════════════════════════════════════ */
namespace EnterpriseSuite.Services
{
    using EnterpriseSuite.Models.Menu;

    public interface IMenuService
    {
        Task<List<MenuItemDto>> GetMenuForUserAsync(string userId, List<string> roles);
    }
}

/* ═══════════════════════════════════════════════════════════
   SERVICE IMPLEMENTATION (Demo/Sample data)
   Replace the hardcoded list with DB queries as needed.
═══════════════════════════════════════════════════════════ */
namespace EnterpriseSuite.Services
{
    using EnterpriseSuite.Models.Menu;

    public class MenuService : IMenuService
    {
        // Inject your DbContext or repository here
        // private readonly AppDbContext _db;

        public async Task<List<MenuItemDto>> GetMenuForUserAsync(string userId, List<string> roles)
        {
            // ── Build the full menu definition ──────────────────────────
            // In production: load from database, filter by roles/permissions.
            // Each item's Permission flag is evaluated against the user's roles.

            bool isAdmin    = roles.Contains("SuperAdmin") || roles.Contains("Admin");
            bool hasCrm     = isAdmin || roles.Contains("CRM");
            bool hasHr      = isAdmin || roles.Contains("HR");
            bool hasPayroll = isAdmin || roles.Contains("Payroll");
            bool hasAttend  = isAdmin || roles.Contains("Attendance");
            bool hasReports = isAdmin || roles.Contains("Reports");

            var menu = new List<MenuItemDto>
            {
                // ── DASHBOARD ────────────────────────────────────────────
                new() {
                    Id         = "dashboard",
                    Label      = "Dashboard",
                    Icon       = "fa-solid fa-gauge-high",
                    Section    = "Overview",
                    Url        = "/Dashboard/Index",
                    Permission = true,
                    Order      = 1
                },

                // ── CRM ──────────────────────────────────────────────────
                new() {
                    Id         = "crm",
                    Label      = "CRM",
                    Icon       = "fa-solid fa-briefcase",
                    Section    = "Business",
                    Permission = hasCrm,
                    Order      = 10,
                    Children   = new()
                    {
                        new() {
                            Id         = "crm-contacts",
                            Label      = "Contacts",
                            Icon       = "fa-solid fa-address-book",
                            Permission = hasCrm,
                            Order      = 1,
                            Children   = new()
                            {
                                new() { Id="crm-contacts-list",  Label="All Contacts",  Icon="fa-solid fa-list",        Url="/CRM/Contacts/Index",  Permission=hasCrm,  Order=1 },
                                new() { Id="crm-contacts-add",   Label="Add Contact",   Icon="fa-solid fa-plus",        Url="/CRM/Contacts/Create", Permission=hasCrm,  Order=2 },
                                new() { Id="crm-contacts-import",Label="Import",        Icon="fa-solid fa-file-import", Url="/CRM/Contacts/Import", Permission=isAdmin, Order=3 }
                            }
                        },
                        new() {
                            Id         = "crm-leads",
                            Label      = "Leads",
                            Icon       = "fa-solid fa-funnel-dollar",
                            Badge      = "8",
                            Permission = hasCrm,
                            Order      = 2,
                            Children   = new()
                            {
                                new() { Id="crm-leads-list",   Label="All Leads",    Icon="fa-solid fa-list",  Url="/CRM/Leads/Index",  Permission=hasCrm, Order=1 },
                                new() { Id="crm-leads-add",    Label="Add Lead",     Icon="fa-solid fa-plus",  Url="/CRM/Leads/Create", Permission=hasCrm, Order=2 },
                                new() { Id="crm-leads-kanban", Label="Kanban Board", Icon="fa-solid fa-table-columns", Url="/CRM/Leads/Kanban", Permission=hasCrm, Order=3 }
                            }
                        },
                        new() {
                            Id         = "crm-accounts",
                            Label      = "Accounts",
                            Icon       = "fa-solid fa-building",
                            Permission = hasCrm,
                            Order      = 3,
                            Children   = new()
                            {
                                new() { Id="crm-accounts-list", Label="All Accounts", Icon="fa-solid fa-list", Url="/CRM/Accounts/Index",  Permission=hasCrm, Order=1 },
                                new() { Id="crm-accounts-add",  Label="Add Account",  Icon="fa-solid fa-plus", Url="/CRM/Accounts/Create", Permission=hasCrm, Order=2 }
                            }
                        },
                        new() { Id="crm-activities", Label="Activities", Icon="fa-solid fa-calendar-check", Url="/CRM/Activities/Index",  Permission=hasCrm, Order=4 },
                        new() { Id="crm-pipeline",   Label="Sales Pipeline", Icon="fa-solid fa-chart-gantt", Url="/CRM/Pipeline/Index",  Permission=hasCrm, Order=5 }
                    }
                },

                // ── HR ───────────────────────────────────────────────────
                new() {
                    Id         = "hr",
                    Label      = "Human Resources",
                    Icon       = "fa-solid fa-users",
                    Section    = "HR & Payroll",
                    Permission = hasHr,
                    Order      = 20,
                    Children   = new()
                    {
                        new() { Id="hr-employees",    Label="Employees",    Icon="fa-solid fa-user-tie",   Url="/HR/Employees/Index",   Permission=hasHr, Order=1 },
                        new() { Id="hr-departments",  Label="Departments",  Icon="fa-solid fa-sitemap",    Url="/HR/Departments/Index", Permission=hasHr, Order=2 },
                        new() { Id="hr-designations", Label="Designations", Icon="fa-solid fa-id-badge",   Url="/HR/Designations/Index",Permission=hasHr, Order=3 },
                        new() {
                            Id="hr-leave", Label="Leave Management", Icon="fa-solid fa-calendar-xmark",
                            Permission=hasHr, Order=4,
                            Children=new()
                            {
                                new() { Id="hr-leave-types",    Label="Leave Types",    Icon="fa-solid fa-tags",        Url="/HR/Leave/Types",    Permission=hasHr, Order=1 },
                                new() { Id="hr-leave-requests", Label="Leave Requests", Icon="fa-solid fa-inbox",       Url="/HR/Leave/Requests", Permission=hasHr, Order=2, Badge="3" },
                                new() { Id="hr-leave-balance",  Label="Leave Balance",  Icon="fa-solid fa-scale-balanced", Url="/HR/Leave/Balance",Permission=hasHr, Order=3 }
                            }
                        },
                        new() { Id="hr-onboarding",  Label="Onboarding",  Icon="fa-solid fa-user-plus",  Url="/HR/Onboarding/Index",  Permission=isAdmin, Order=5 },
                        new() { Id="hr-documents",   Label="Documents",   Icon="fa-solid fa-folder-open",Url="/HR/Documents/Index",   Permission=hasHr,   Order=6 }
                    }
                },

                // ── PAYROLL ──────────────────────────────────────────────
                new() {
                    Id         = "payroll",
                    Label      = "Payroll",
                    Icon       = "fa-solid fa-money-bill-wave",
                    Permission = hasPayroll,
                    Order      = 30,
                    Children   = new()
                    {
                        new() { Id="payroll-process",   Label="Process Payroll",  Icon="fa-solid fa-play-circle",   Url="/Payroll/Process",     Permission=isAdmin,    Order=1 },
                        new() { Id="payroll-slips",     Label="Pay Slips",        Icon="fa-solid fa-file-invoice",  Url="/Payroll/Slips/Index", Permission=hasPayroll, Order=2 },
                        new() { Id="payroll-salary",    Label="Salary Structure", Icon="fa-solid fa-layer-group",   Url="/Payroll/Salary/Index",Permission=isAdmin,    Order=3 },
                        new() { Id="payroll-deductions",Label="Deductions",       Icon="fa-solid fa-minus-circle",  Url="/Payroll/Deductions",  Permission=isAdmin,    Order=4 },
                        new() { Id="payroll-tax",       Label="Tax Setup",        Icon="fa-solid fa-percent",       Url="/Payroll/Tax",         Permission=isAdmin,    Order=5 }
                    }
                },

                // ── ATTENDANCE ───────────────────────────────────────────
                new() {
                    Id         = "attendance",
                    Label      = "Attendance",
                    Icon       = "fa-solid fa-clock",
                    Permission = hasAttend,
                    Order      = 40,
                    Children   = new()
                    {
                        new() { Id="attend-daily",    Label="Daily Attendance", Icon="fa-solid fa-calendar-day",  Url="/Attendance/Daily",   Permission=hasAttend, Order=1 },
                        new() { Id="attend-monthly",  Label="Monthly Report",   Icon="fa-solid fa-calendar-alt",  Url="/Attendance/Monthly", Permission=hasAttend, Order=2 },
                        new() { Id="attend-shifts",   Label="Shift Management", Icon="fa-solid fa-rotate",        Url="/Attendance/Shifts",  Permission=isAdmin,   Order=3 },
                        new() { Id="attend-overtime",  Label="Overtime",        Icon="fa-solid fa-hourglass-half",Url="/Attendance/Overtime",Permission=hasAttend, Order=4 }
                    }
                },

                // ── REPORTS ──────────────────────────────────────────────
                new() {
                    Id         = "reports",
                    Label      = "Reports",
                    Icon       = "fa-solid fa-chart-bar",
                    Section    = "Analytics",
                    Permission = hasReports,
                    Order      = 50,
                    Children   = new()
                    {
                        new() { Id="reports-crm",      Label="CRM Reports",     Icon="fa-solid fa-chart-line",  Url="/Reports/CRM",     Permission=hasReports && hasCrm,     Order=1 },
                        new() { Id="reports-hr",       Label="HR Reports",      Icon="fa-solid fa-chart-pie",   Url="/Reports/HR",      Permission=hasReports && hasHr,      Order=2 },
                        new() { Id="reports-payroll",  Label="Payroll Reports", Icon="fa-solid fa-receipt",     Url="/Reports/Payroll", Permission=hasReports && hasPayroll, Order=3 },
                        new() { Id="reports-attend",   Label="Attendance Reports",Icon="fa-solid fa-table",    Url="/Reports/Attendance",Permission=hasReports && hasAttend, Order=4 }
                    }
                },

                // ── ADMINISTRATION ───────────────────────────────────────
                new() {
                    Id         = "admin",
                    Label      = "Administration",
                    Icon       = "fa-solid fa-shield-halved",
                    Section    = "System",
                    Permission = isAdmin,
                    Order      = 90,
                    Children   = new()
                    {
                        new() { Id="admin-users",    Label="Users",        Icon="fa-solid fa-users-gear",  Url="/Admin/Users",       Permission=isAdmin, Order=1 },
                        new() { Id="admin-roles",    Label="Roles",        Icon="fa-solid fa-user-lock",   Url="/Admin/Roles",       Permission=isAdmin, Order=2 },
                        new() { Id="admin-settings", Label="Settings",     Icon="fa-solid fa-sliders",     Url="/Admin/Settings",    Permission=isAdmin, Order=3 },
                        new() { Id="admin-audit",    Label="Audit Logs",   Icon="fa-solid fa-scroll",      Url="/Admin/AuditLogs",   Permission=isAdmin, Order=4 },
                        new() { Id="admin-backup",   Label="Backup",       Icon="fa-solid fa-database",    Url="/Admin/Backup",      Permission=isAdmin, Order=5 }
                    }
                }
            };

            // Filter items where Permission is false + filter children recursively
            return FilterMenu(menu);
        }

        private static List<MenuItemDto> FilterMenu(List<MenuItemDto> items)
        {
            var result = new List<MenuItemDto>();
            foreach (var item in items.Where(i => i.Permission).OrderBy(i => i.Order))
            {
                if (item.Children != null && item.Children.Count > 0)
                {
                    item.Children = FilterMenu(item.Children);
                    // Keep parent even if all children are filtered (parent may also have url)
                }
                result.Add(item);
            }
            return result;
        }
    }
}
