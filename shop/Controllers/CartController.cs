using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private ProductsStorage _productsStorage;
        private CartsStorage _cartsStorage;

        public CartController(ProductsStorage productsStorage, CartsStorage cartsStorage) 
        {
            _productsStorage = productsStorage;
            _cartsStorage = cartsStorage;
        }

        public IActionResult Index(string userId = "1")
        {
            var cart = _cartsStorage.TryGetCardByUserId(userId);

            return View(cart);
        }

        public IActionResult Add(int productId, string userId = "1")
        {
            var product = _productsStorage.TryGetById(productId);
            _cartsStorage.Add(product, userId);

            return RedirectToAction("Index");
        }
    }
}
