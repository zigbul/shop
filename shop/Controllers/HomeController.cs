using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using shop.Models;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public HomeController(IProductsStorage productsStorage)
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
