using Microsoft.AspNetCore.Mvc;
using shop.Models;
using System.Diagnostics;
using OnlineShopWebApp.Properties.Helpers;
using OnlineShopWebApp.Services;
using OnlineShop.Db.Services;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage _productsStorage;
        private readonly IUsersStorage _usersStorage;

        public HomeController(IProductsStorage productsStorage, IUsersStorage usersStorage)
        {
            _productsStorage = productsStorage;
            _usersStorage = usersStorage;
        }

        public IActionResult Index(string? searchName)
        {
            var productsDb = _productsStorage.GetAll();
            var products = productsDb.ToProductViewModel();

            if (string.IsNullOrEmpty(searchName) == false || string.IsNullOrWhiteSpace(searchName) == false)
            {
                products = products
                    .Where(p => p.Name.ToLower().Contains(searchName.ToLower()))
                    .ToList();
            }

            ViewBag.UserId = _usersStorage.GetCurrentUserId();
            ViewBag.SearchName = searchName;
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
