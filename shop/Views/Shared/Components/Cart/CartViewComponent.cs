using Microsoft.AspNetCore.Mvc;
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
            var cart = _cartsStorage.TryGetCardByUserId("1");
            var allItemsAmount = cart?.ItemsAmount;

            return View("Cart", allItemsAmount);
        }
    }
}
