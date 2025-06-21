using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductsStorage _productsStorage;
        private readonly IOrdersStorage _ordersStorage;
        private readonly IRolesStorage _rolesStorage;

        public HomeController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRolesStorage rolesStorage)
        {
            _productsStorage = productsStorage;
            _ordersStorage = ordersStorage;
            _rolesStorage = rolesStorage;
        }

        public IActionResult Orders()
        {
            var orders = _ordersStorage.GetAll();

            return View(orders);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = _rolesStorage.GetAll();

            return View(roles);
        }

        public IActionResult Products()
        {
            var products = _productsStorage.GetAll();

            return View(products);
        }
    }
}
