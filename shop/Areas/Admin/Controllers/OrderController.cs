using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models.Enums;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersStorage _ordersStorage;

        public OrderController(IOrdersStorage ordersStorage)
        {
            _ordersStorage = ordersStorage;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var order = _ordersStorage.TryGetById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Details(int id, OrderStatuses status)
        {
            var order = _ordersStorage.TryGetById(id);

            if (order != null)
            {
                order.Status = status;
            }

            return View(order);
        }
    }
}
