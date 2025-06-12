using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsStorage _productsStorage;

        public CartController() 
        {
            _productsStorage = new ProductsStorage();
        }

        public IActionResult Index(string userId = "1")
        {
            var cart = CartsStorage.TryGetCardByUserId(userId);

            return View(cart);
        }

        public IActionResult Add(int productId, string userId = "1")
        {
            var product = _productsStorage.TryGetById(productId);
            CartsStorage.Add(product, userId);

            return RedirectToAction("Index");
        }
    }
}
