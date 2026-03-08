using bdDevCRM.FrontEnd.Context;
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

builder.Services.AddScoped<IMenuService, MenuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();       // ← MapStaticAssets() এর বদলে এটা MVC-তে সঠিক
app.UseRouting();
app.UseAuthorization();

// MVC default route
app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();