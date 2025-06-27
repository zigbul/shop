using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;

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
        public IActionResult Index(OrderViewModel order)
        {
            var userId = Guid.Parse("5c18c843-52c5-455d-b44f-bec0913d047d");
            var cartDb = _cartsStorage.TryGetCardByUserId(userId);

            if (ModelState.IsValid && cartDb != null)
            {
                var oderDb = new Order()
                {
                    Name = order.Name,
                    Address = order.Address,
                    Email = order.Email,
                    Phone = order.Phone,
                    Items = cartDb.Items.Select(item => new OrderItem()
                    {
                        ProductId = item.Product.Id,
                        OrderId = order.Id,
                        Amount = item.Amount,
                    })
                    .ToList(),
                };

                _ordersStorage.Add(oderDb);
                _cartsStorage.Remove(cartDb);

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
