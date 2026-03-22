namespace bdDevCRM.FrontEnd.Middleware;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;

  // এই routes-এ authentication check হবে না
  private static readonly string[] PublicPaths = ["/account/login", "/account/logout", "/account/forgotpassword" ];

  public AuthMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    var path = context.Request.Path.Value?.ToLower() ?? "";

    // Static files bypass করো
    if (path.StartsWith("/css") || path.StartsWith("/js") ||
        path.StartsWith("/lib") || path.StartsWith("/images") ||
        path.StartsWith("/favicon"))
    {
      await _next(context);
      return;
    }

    // Public paths bypass করো
    if (PublicPaths.Any(p => path.StartsWith(p)))
    {
      await _next(context);
      return;
    }

    // Session check করো
    var userJson = context.Session.GetString("CurrentUser");

    if (string.IsNullOrEmpty(userJson))
    {
      // AJAX request হলে 401 return করো
      if (context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
      {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsJsonAsync(new
        {
          success = false,
          message = "Session expired. Please login again.",
          redirectUrl = "/Account/Login"
        });
        return;
      }

      // Normal request হলে login-এ redirect করো
      var returnUrl = Uri.EscapeDataString(context.Request.Path + context.Request.QueryString);
      context.Response.Redirect($"/Account/Login?returnUrl={returnUrl}");
      return;
    }

    await _next(context);
  }
}

