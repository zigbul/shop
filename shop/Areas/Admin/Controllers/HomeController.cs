using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Properties.Helpers;
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
            var ordersDb = _ordersStorage.GetAll();
            var orders = ordersDb.ToOrderViewModel();

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
            var productsDb = _productsStorage.GetAll();
            var products = new List<ProductViewModel>();

            foreach (var productDb in productsDb)
            {
                var product = new ProductViewModel
                {
                    Id = productDb.Id,
                    Name = productDb.Name,
                    Price = productDb.Price,
                    Description = productDb.Description,
                    ImageUrl = productDb.ImageUrl,
                };

                products.Add(product);
            }

            return View(products);
        }
    }
}
