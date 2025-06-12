using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using shop.Models;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsStorage _productsStorage;

        public HomeController(ProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var products = _productsStorage.GetAll();

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
