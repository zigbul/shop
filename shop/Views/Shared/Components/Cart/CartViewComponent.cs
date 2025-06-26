using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Properties.Helpers;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage _cartsStorage;

        public CartViewComponent(ICartsStorage cartsStorage)
        {
            _cartsStorage = cartsStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cartDb = _cartsStorage.TryGetCardByUserId(Guid.NewGuid());
            var cart = MapperHelper.ToCartViewModel(cartDb);

            var allItemsAmount = cart?.ItemsAmount;

            return View("Cart", allItemsAmount);
        }
    }
}
