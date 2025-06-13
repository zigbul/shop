using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ICartsStorage _cartsStorage;
        private IOrdersStorage _ordersStorage;

        public OrderController(ICartsStorage cartsStorage, IOrdersStorage ordersStorage) 
        {
            _cartsStorage = cartsStorage;
            _ordersStorage = ordersStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            var cart = _cartsStorage.TryGetCardByUserId("1");

            _cartsStorage.Remove(cart);
            _ordersStorage.Add(cart);

            return View();
        }
    }
}
