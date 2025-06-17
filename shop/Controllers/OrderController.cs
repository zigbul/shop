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

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsVisible = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            order.Cart = _cartsStorage.TryGetCardByUserId("1");

            if (ModelState.IsValid && order.Cart != null)
            {
                _ordersStorage.Add(order);
                _cartsStorage.Remove(order.Cart);

                ViewBag.IsVisible = true;
                return RedirectToAction("Success");
            }

            ViewBag.IsVisible = false;
            return View(order);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
