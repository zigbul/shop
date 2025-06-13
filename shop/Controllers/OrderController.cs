using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
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

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var cart = _cartsStorage.TryGetCardByUserId("1");

            order.cart = cart;

            _ordersStorage.Add(order);
            _cartsStorage.Remove(cart);

            return View();
        }
    }
}
