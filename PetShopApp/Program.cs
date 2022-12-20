using Microsoft.EntityFrameworkCore;
using PetShopApp.Data;
using PetShopApp.Models;
using PetShopApp.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository<Animal>, Repository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<PetShopContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Login/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=index}/{id?}");
});

app.Run();
