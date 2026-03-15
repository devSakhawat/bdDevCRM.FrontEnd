using bdDevCRM.FrontEnd.Models.Auth;

namespace bdDevCRM.FrontEnd.Services;

public interface IAuthService
{
  Task<(bool IsValid, string Message, CurrentUserDto? User)>
      ValidateUserAsync(string loginId, string password);
}