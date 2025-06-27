using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Services;
using OnlineShop.Dbp.Models.Enums;
using OnlineShopWebApp.Properties.Helpers;

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
        public IActionResult Details(Guid id)
        {
            var order = _ordersStorage.TryGetById(id);

            return View(order?.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult Details(Guid id, OrderStatuses status)
        {
            var order = _ordersStorage.TryGetById(id);

            if (order != null)
            {
                _ordersStorage.ChangeStatus(id, status);
                order.Status = status;
            }

            return View(order?.ToOrderViewModel());
        }
    }
}
