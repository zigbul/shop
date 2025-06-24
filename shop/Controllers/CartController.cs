using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private IProductsStorage _productsStorage;
        private ICartsStorage _cartsStorage;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage) 
        {
            _productsStorage = productsStorage;
            _cartsStorage = cartsStorage;
        }

        public IActionResult Index(string userId = "1")
        {
            var cart = _cartsStorage.TryGetCardByUserId(userId);

            return View(cart);
        }

        public IActionResult Add(Guid productId, string userId = "1")
        {
            var product = _productsStorage.TryGetById(productId);
            _cartsStorage.IncreaseItemAmount(product, userId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid itemId, Guid cartId)
        {
            _cartsStorage.DecreaseItemAmount(itemId, cartId);

            return RedirectToAction("Index");
        }
    }
}
