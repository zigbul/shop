using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using shop.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public HomeController(IProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Index(string? searchName = null)
        {
            var products = _productsStorage.GetAll();

            if (string.IsNullOrEmpty(searchName) == false || string.IsNullOrWhiteSpace(searchName) == false)
            {
                products = products
                    .Where(p => p.Name.ToLower().Contains(searchName.ToLower()))
                    .ToList();
            }

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
