using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public ProductController(IProductsStorage productsStorage)
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
