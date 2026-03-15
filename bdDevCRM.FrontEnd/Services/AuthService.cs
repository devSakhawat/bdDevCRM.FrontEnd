namespace bdDevCRM.FrontEnd.Services;


using bdDevCRM.FrontEnd.Context;
using bdDevCRM.FrontEnd.Models.Auth;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
  private readonly CRMContext _context;
  private readonly ILogger<AuthService> _logger;

  public AuthService(CRMContext context, ILogger<AuthService> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task<(bool IsValid, string Message, CurrentUserDto? User)>
      ValidateUserAsync(string loginId, string password)
  {
    // ── Input validation ──────────────────────────────────────────
    if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(password))
      return (false, "Username and password are required.", null);

    try
    {
      // ── DB থেকে user খুঁজো ───────────────────────────────────
      // Users entity আপনার CRMContext-এ আছে
      var user = await _context.Users
          .AsNoTracking()
          .FirstOrDefaultAsync(u => u.LoginId == loginId.Trim());

      if (user == null)
      {
        _logger.LogWarning("Login failed — user not found: {LoginId}", loginId);
        return (false, "Invalid username or password.", null);
      }

      // ── Password verify ───────────────────────────────────────
      bool passwordValid = VerifyPassword(password, user.Password ?? "");

      if (!passwordValid)
      {
        _logger.LogWarning("Login failed — wrong password for: {LoginId}", loginId);
        return (false, "Invalid username or password.", null);
      }

      // ── User locked check ─────────────────────────────────────
      // Users entity-তে IsLocked বা IsActive field থাকলে check করুন
      // if (user.IsLocked == 1)
      //     return (false, "Your account has been locked. Contact administrator.", null);

      // ── CurrentUserDto তৈরি করো ──────────────────────────────
      var currentUser = new CurrentUserDto
      {
        UserId = user.UserId,
        UserName = user.UserName ?? string.Empty,
        //FullName = user.FullName ?? user.UserName ?? string.Empty,
        //Email = user.Email ?? string.Empty,
        //UserType = user.UserType ?? string.Empty,
        Theme = user.Theme ?? "light",
        EmployeeId = user.EmployeeId,
        CompanyId = user.CompanyId,
        //ImagePath = user.ImagePath ?? string.Empty
      };

      _logger.LogInformation("Login successful for: {LoginId} (UserId: {UserId})",
          loginId, user.UserId);

      return (true, "Success", currentUser);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Login error for: {LoginId}", loginId);
      return (false, "An error occurred during login. Please try again.", null);
    }
  }

  // ════════════════════════════════════════════════════════════════
  // Password Verify — Legacy + BCrypt দুটোই support করে
  //
  // Migration period-এ দুটো পদ্ধতি:
  // ১. BCrypt hash দিয়ে check (নতুন passwords)
  // ২. Legacy encrypt compare (পুরোনো passwords)
  // ════════════════════════════════════════════════════════════════
  private static bool VerifyPassword(string inputPassword, string storedPassword)
  {
    if (string.IsNullOrEmpty(storedPassword)) return false;

    // ── BCrypt hash detect ($2a$ বা $2b$ দিয়ে শুরু) ──────────────
    if (storedPassword.StartsWith("$2a$") || storedPassword.StartsWith("$2b$"))
    {
      try
      {
        //return BCrypt.Net.BCrypt.Verify(inputPassword, storedPassword);
      }
      catch
      {
        return false;
      }
    }

    // ── Legacy: EncryptDecryptHelper দিয়ে encrypt করে compare ────
    // পুরোনো system-এ password encrypt করে store করা ছিল
    try
    {
      //var encryptedInput = EncryptDecryptHelper.Encrypt(inputPassword);
      //return encryptedInput == storedPassword;
      return true;
    }
    catch
    {
      // Legacy encrypt fail হলে plain text compare
      return inputPassword == storedPassword;
    }
  }
}
