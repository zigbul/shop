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
        private readonly IUsersStorage _usersStorage;

        public HomeController
        (
            IProductsStorage productsStorage,
            IOrdersStorage ordersStorage,
            IRolesStorage rolesStorage,
            IUsersStorage usersStorage
        )
        {
            _productsStorage = productsStorage;
            _ordersStorage = ordersStorage;
            _rolesStorage = rolesStorage;
            _usersStorage = usersStorage;
        }

        public IActionResult Orders()
        {
            var orders = _ordersStorage.GetAll();

            return View(orders);
        }

        public IActionResult Users()
        {
            var users = _usersStorage.GetAll();

            return View(users);
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
