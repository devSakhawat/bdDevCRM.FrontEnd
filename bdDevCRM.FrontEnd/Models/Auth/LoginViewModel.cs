namespace bdDevCRM.FrontEnd.Models.Auth;

// ═══════════════════════════════════════════════════════════════
// FILE 1: LoginViewModel.cs
// Location: bdDevCRM.FrontEnd/Models/Auth/LoginViewModel.cs
// ═══════════════════════════════════════════════════════════════


/// <summary>
/// Login form POST data
/// </summary>
public class LoginViewModel
{
  public string LoginId { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public bool RememberMe { get; set; }
}

/// <summary>
/// JSON response to JavaScript fetch()
/// </summary>
public class LoginResponseDto
{
  public bool Success { get; set; }
  public string Message { get; set; } = string.Empty;
  public string RedirectUrl { get; set; } = "/Home/Index";
}

/// <summary>
/// Logged-in user info — stored in Session and HttpContext.Items
/// </summary>
public class CurrentUserDto
{
  public int UserId { get; set; }
  public string UserName { get; set; } = string.Empty;
  public string FullName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string UserType { get; set; } = string.Empty;
  public string Theme { get; set; } = "light";
  public int? EmployeeId { get; set; }
  public int? CompanyId { get; set; }
  public string ImagePath { get; set; } = string.Empty;
}
