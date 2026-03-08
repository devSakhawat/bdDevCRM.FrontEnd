using bdDevCRM.FrontEnd.Context;
using bdDevCRM.FrontEnd.Services;          // ← EnterpriseSuite.Services থেকে এটায় বদলান
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
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//app.MapControllerRoute(
//		name: "default",
//		pattern: "{controller=Home}/{action=Index}/{id?}")
//		.WithStaticAssets();
app.MapControllers();

app.Run();
