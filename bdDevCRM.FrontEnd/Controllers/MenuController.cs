namespace bdDevCRM.FrontEnd.Controllers
{
	using EnterpriseSuite.Services;
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;

	[Route("Menu")]                      // ← Controller-level route
	public class MenuController : Controller
	{
		private readonly IMenuService _menuService;

		public MenuController(IMenuService menuService)
		{
			_menuService = menuService;
		}

		[HttpGet("GetSidebarMenu")]       // ← Action-level route
		public async Task<IActionResult> GetSidebarMenu()
		{
			try
			{
				// Development-এ userId = 1 hardcode
				// Production-এ Claims থেকে নিন
				var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
				int userId = int.TryParse(userIdClaim, out int id) ? id : 1;

				var menuTree = await _menuService.GetMenuByUserIdAsync(userId);

				return Json(menuTree, new System.Text.Json.JsonSerializerOptions
				{
					PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
					DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
					WriteIndented = false
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Menu load failed.", error = ex.Message });
			}
		}
	}
}