using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using GolfPlatform.Data;
using GolfPlatform.Data.Repositories;
using GolfPlatform.Domain.Usecases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(System.Environment.GetEnvironmentVariable("APPDB_CONTEXT") ?? builder.Configuration.GetConnectionString("AppDbContext"))
);

builder.Host.ConfigureServices(services =>
{
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserUsecases, UserUsecases>();
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => options.LoginPath = "/login");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=Index}");
app.MapControllerRoute(
name: "login",
pattern: "{controller=Api}/api/{action=Index}");

app.Run();
