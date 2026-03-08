namespace bdDevCRM.FrontEnd.Models.Menu;

public class SidebarMenuItemDto
{
	/// <summary>
	/// Unique string ID — JS-এ active state track করতে ব্যবহার হয়।
	/// Format: "menu-{MenuId}" যেমন "menu-5"
	/// </summary>
	public string Id { get; set; } = string.Empty;

	/// <summary>Sidebar-এ যে text দেখাবে।</summary>
	public string Label { get; set; } = string.Empty;

	/// <summary>
	/// Font Awesome icon class।
	/// ModuleId বা MenuName দেখে icon assign করা হয়।
	/// যেমন: "fa-solid fa-briefcase"
	/// </summary>
	public string Icon { get; set; } = string.Empty;

	/// <summary>
	/// Section divider label।
	/// ModuleId দেখে assign হয়: CRM, HR &amp; Payroll, Analytics ইত্যাদি।
	/// শুধু top-level root items-এর জন্য প্রযোজ্য।
	/// </summary>
	public string? Section { get; set; }

	/// <summary>
	/// Click করলে fetch() দিয়ে এই URL load হবে।
	/// Parent items-এর জন্য null (তাদের শুধু accordion toggle হয়)।
	/// </summary>
	public string? Url { get; set; }

	/// <summary>
	/// Menu item-এর পাশে ছোট badge দেখায়।
	/// Todo > 0 হলে এখানে সেই সংখ্যা আসে।
	/// </summary>
	public string? Badge { get; set; }

	/// <summary>Sort order।</summary>
	public int Order { get; set; }

	/// <summary>
	/// Child menu items (Level 2 এবং Level 3)।
	/// JavaScript এই nested array দেখে accordion তৈরি করে।
	/// </summary>
	public List<SidebarMenuItemDto>? Children { get; set; }

	// ── Internal use only — JSON-এ serialize হবে না ──────────────────
	/// <summary>Tree build করার সময় parent খুঁজতে ব্যবহার হয়।</summary>
	[System.Text.Json.Serialization.JsonIgnore]
	public int RawMenuId { get; set; }

	/// <summary>Tree build করার সময় parent-child সম্পর্ক বুঝতে ব্যবহার হয়।</summary>
	[System.Text.Json.Serialization.JsonIgnore]
	public int? RawParentMenuId { get; set; }
}
