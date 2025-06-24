using Microsoft.AspNetCore.Mvc;
using shop.Models;
using System.Diagnostics;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

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
            var productsDb = _productsStorage.GetAll();
            var products = new List<ProductViewModel>();

            foreach (var productDb in productsDb) 
            {
                var product = new ProductViewModel
                {
                    Id = productDb.Id,
                    Name = productDb.Name,
                    Price = productDb.Price,
                    Description = productDb.Description,
                    ImageUrl = productDb.ImageUrl,
                };

                products.Add(product);
            }

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
