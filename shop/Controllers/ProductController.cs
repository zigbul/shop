using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsStorage _productsStorage;

        public ProductController(ProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Index(int id = 1)
        {
            var product = _productsStorage.TryGetById(id);

            return View(product);
        }
    }
}
