using bdDevCRM.FrontEnd.Context;
using bdDevCRM.FrontEnd.Middleware;
using bdDevCRM.FrontEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CRMContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("DbLocation")
                      ?? builder.Configuration["ConnectionStrings:DbLocation"];
  options.UseSqlServer(connectionString);
});

// ── Services ──────────────────────────────────────────────────
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// ── Session ───────────────────────────────────────────────────
builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromHours(8);    // 4 Hours
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
  options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
  options.Cookie.SameSite = SameSiteMode.Strict;
  options.Cookie.Name = ".bdDevCRM.Session";
}); ;

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Home/Error");
//	app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseMiddleware<AuthMiddleware>();
app.UseAuthorization();

// MVC default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();