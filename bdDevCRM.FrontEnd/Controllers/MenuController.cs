namespace bdDevCRM.FrontEnd.Controllers
{
	using bdDevCRM.FrontEnd.Services;
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

    //[HttpGet("GetSidebarMenu")]
    //public async Task<IActionResult> GetSidebarMenu()
    //{
    //	try
    //	{
    //		// Development-এ userId = 1 hardcode
    //		var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //		int userId = int.TryParse(userIdClaim, out int id) ? id : 1;

    //		var menuTree = await _menuService.GetMenuByUserIdAsync(userId);

    //		return Json(menuTree, new System.Text.Json.JsonSerializerOptions
    //		{
    //			PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
    //			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    //			WriteIndented = false
    //		});
    //	}
    //	catch (Exception ex)
    //	{
    //		return StatusCode(500, new { message = "Menu load failed.", error = ex.Message });
    //	}
    //}

    [HttpGet]
    [Route("Menu/GetSidebarMenu")]
    public async Task<IActionResult> GetSidebarMenu()
    {
      try
      {
        var currentUser = AccountController.GetCurrentUser(HttpContext);

        if (currentUser == null)
          return Unauthorized(new { message = "Session expired." });

        var menuTree = await _menuService.GetMenuByUserIdAsync(currentUser.UserId);

        return Json(menuTree, new System.Text.Json.JsonSerializerOptions
        {
          PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
          DefaultIgnoreCondition = System.Text.Json.Serialization
                                        .JsonIgnoreCondition.WhenWritingNull,
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