using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Properties.Helpers;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsStorage _productsStorage;
        private readonly ICartsStorage _cartsStorage;
        private readonly IUsersStorage _usersStorage;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage, IUsersStorage usersStorage)
        {
            _productsStorage = productsStorage;
            _cartsStorage = cartsStorage;
            _usersStorage = usersStorage;
        }

        public IActionResult Index()
        {
            var userId = Guid.Parse("5c18c843-52c5-455d-b44f-bec0913d047d");
            var cartDb = _cartsStorage.TryGetCardByUserId(userId);

            if (cartDb == null)
            {
                return View(cartDb);
            }

            var cart = new CartViewModel()
            {
                Id = cartDb.Id,
                UserId = cartDb.UserId,
                Items = MapperHelper.ToCartItemViewModel(cartDb.Items),
            };

            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var userId = Guid.Parse("5c18c843-52c5-455d-b44f-bec0913d047d");
            var product = _productsStorage.TryGetById(productId);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _cartsStorage.IncreaseItemAmount(product);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid itemId, Guid cartId)
        {
            _cartsStorage.DecreaseItemAmount(itemId, cartId);

            return RedirectToAction("Index");
        }
    }
}
