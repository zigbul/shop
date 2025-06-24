using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Index(Guid id)
        {
            var productDb = _productsStorage.TryGetById(id);
            var product = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Price = productDb.Price,
                Description = productDb.Description,
                ImageUrl = productDb.ImageUrl
            };

            return View(product);
        }
    }
}
