using bdDevCRM.FrontEnd.Models.Auth;
using bdDevCRM.FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace bdDevCRM.FrontEnd.Controllers;

public class AccountController : Controller
{
  private readonly IAuthService _authService;
  private readonly ILogger<AccountController> _logger;

  // Session key constant —
  public const string SESSION_CURRENT_USER = "CurrentUser";
  public const string SESSION_LOGIN_TIME = "LoginTime";
  public const string SESSION_THEME = "Theme";

  public AccountController(IAuthService authService, ILogger<AccountController> logger)
  {
    _authService = authService;
    _logger = logger;
  }

  // ── GET: /Account/Login ───────────────────────────────────────────
  [HttpGet]
  public IActionResult Login(string? returnUrl = null)
  {
    // Already logged in হলে dashboard-এ redirect করো
    var existingUser = HttpContext.Session.GetString(SESSION_CURRENT_USER);
    if (!string.IsNullOrEmpty(existingUser))
      return RedirectToAction("Index", "Home");

    ViewBag.ReturnUrl = returnUrl;
    return View(new LoginViewModel());
  }

  // ── POST: /Account/Login (AJAX fetch) ────────────────────────────
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Login([FromBody] LoginViewModel model)
  {
    // ── Input validation ──────────────────────────────────────────
    if (model == null ||
        string.IsNullOrWhiteSpace(model.LoginId) ||
        string.IsNullOrWhiteSpace(model.Password))
    {
      return Json(new LoginResponseDto
      {
        Success = false,
        Message = "Username and password are required."
      });
    }

    // ── Auth service call ─────────────────────────────────────────
    var (isValid, message, currentUser) =
        await _authService.ValidateUserAsync(model.LoginId, model.Password);

    if (!isValid || currentUser == null)
    {
      return Json(new LoginResponseDto
      {
        Success = false,
        Message = message
      });
    }

    // ── Session set করো ───────────────────────────────────────────
    // CurrentUser JSON হিসেবে session-এ store করা হচ্ছে
    var userJson = System.Text.Json.JsonSerializer.Serialize(currentUser);
    HttpContext.Session.SetString(SESSION_CURRENT_USER, userJson);
    HttpContext.Session.SetString(SESSION_LOGIN_TIME, DateTime.Now.ToString("o"));
    HttpContext.Session.SetString(SESSION_THEME, currentUser.Theme);

    // ── Remember me — Cookie ──────────────────────────────────────
    if (model.RememberMe)
    {
      Response.Cookies.Append("rm_user", model.LoginId, new CookieOptions
      {
        Expires = DateTimeOffset.UtcNow.AddDays(15),
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Strict
      });
    }

    _logger.LogInformation("User logged in: {UserName} (Id: {UserId})",
        currentUser.UserName, currentUser.UserId);

    return Json(new LoginResponseDto
    {
      Success = true,
      Message = "Login successful.",
      RedirectUrl = "/Home/Index"
    });
  }

  // ── GET: /Account/Logout ──────────────────────────────────────────
  [HttpGet]
  public IActionResult Logout()
  {
    var userJson = HttpContext.Session.GetString(SESSION_CURRENT_USER);

    if (!string.IsNullOrEmpty(userJson))
    {
      try
      {
        var user = System.Text.Json.JsonSerializer
            .Deserialize<CurrentUserDto>(userJson);
        _logger.LogInformation("User logged out: {UserName}", user?.UserName);
      }
      catch { /* ignore */ }
    }

    // Session clear
    HttpContext.Session.Clear();

    Response.Cookies.Delete("rm_user");

    return RedirectToAction("Login", "Account");
  }

  public static CurrentUserDto? GetCurrentUser(HttpContext httpContext)
  {
    var json = httpContext.Session.GetString(SESSION_CURRENT_USER);
    if (string.IsNullOrEmpty(json)) return null;

    try
    {
      return System.Text.Json.JsonSerializer.Deserialize<CurrentUserDto>(json);
    }
    catch
    {
      return null;
    }
  }
}
