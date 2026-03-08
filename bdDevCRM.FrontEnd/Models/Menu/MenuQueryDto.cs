using Microsoft.EntityFrameworkCore;

namespace bdDevCRM.FrontEnd.Models.Menu;

/// <summary>
/// Raw SQL query result mapper.
/// SQL-এর প্রতিটা column এই DTO-র একটা property-তে map হয়।
/// EF Core-এর FromSqlRaw() এই class ব্যবহার করে result populate করে।
/// </summary>
[Keyless]
public class MenuQueryDto
{
	// ── SQL: Menu.MenuId ──────────────────────────────────────────────
	/// <summary>Menu টেবিলের Primary Key।</summary>
	public int MenuId { get; set; }

	// ── SQL: Menu.ModuleId ────────────────────────────────────────────
	/// <summary>কোন Module-এর অন্তর্গত সেটা চিহ্নিত করে (CRM=1, HR=2 ইত্যাদি)।</summary>
	public int ModuleId { get; set; }

	// ── SQL: GroupMember.UserId ───────────────────────────────────────
	/// <summary>Permission যে User-এর জন্য check হয়েছে।</summary>
	public int UserId { get; set; }

	// ── SQL: GroupPermission.PermissionTableName ──────────────────────
	/// <summary>Permission এর ধরন — এখানে সবসময় 'Menu' আসবে।</summary>
	public string? PermissionTableName { get; set; }

	// ── SQL: Menu.MenuName ────────────────────────────────────────────
	/// <summary>Sidebar-এ যে নাম দেখাবে।</summary>
	public string MenuName { get; set; } = string.Empty;

	// ── SQL: Menu.MenuPath ────────────────────────────────────────────
	/// <summary>
	/// Click করলে যে URL-এ navigate করবে।
	/// Parent menu-গুলোর MenuPath সাধারণত null থাকে।
	/// </summary>
	public string? MenuPath { get; set; }

	// ── SQL: Menu.ParentMenu ──────────────────────────────────────────
	/// <summary>
	/// Parent menu-এর MenuId।
	/// null মানে এটি Root level (top-level) menu।
	/// non-null মানে এটি কোনো parent-এর child।
	/// </summary>
	public int? ParentMenu { get; set; }

	// ── SQL: SORORDER ─────────────────────────────────────────────────
	/// <summary>Menu item-গুলো কোন order-এ দেখাবে তা নির্ধারণ করে।</summary>
	public int? Sororder { get; set; }

	// ── SQL: ToDo ─────────────────────────────────────────────────────
	/// <summary>
	/// Badge counter হিসেবে ব্যবহার করা যায়।
	/// যেমন: Pending tasks, unread notifications ইত্যাদি।
	/// </summary>
	public int? Todo { get; set; }
}
