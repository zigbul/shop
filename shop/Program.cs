using OnlineShopWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductsStorage, InMemoryProductsStorage>();
builder.Services.AddSingleton<ICartsStorage, InMemoryCartsStorage>();
builder.Services.AddSingleton<IOrdersStorage, InMemoryOrdersStorage>();
builder.Services.AddSingleton<IRolesStorage, InMemoryRolesStorage>();
builder.Services.AddSingleton<IUsersStorage, InMemoryUsersStorage>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
