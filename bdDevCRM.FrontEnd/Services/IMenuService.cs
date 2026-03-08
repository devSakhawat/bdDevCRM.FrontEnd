using bdDevCRM.FrontEnd.Models.Menu;

namespace bdDevCRM.FrontEnd.Services;

public interface IMenuService
{
	/// <summary>
	/// দেওয়া userId-এর জন্য permission অনুযায়ী sidebar menu tree লোড করে।
	/// </summary>
	/// <param name="userId">Current logged-in user-এর ID।</param>
	/// <returns>Nested tree structure-এ menu items।</returns>
	Task<List<SidebarMenuItemDto>> GetMenuByUserIdAsync(int userId);
}
