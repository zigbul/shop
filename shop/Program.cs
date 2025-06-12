using OnlineShopWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductsStorage>();
builder.Services.AddSingleton<CartsStorage>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
