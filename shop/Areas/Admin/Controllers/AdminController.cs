using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Enums;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsStorage _productsStorage;
        private readonly IOrdersStorage _ordersStorage;
        private readonly IRolesStorage _rolesStorage;

        public AdminController(IProductsStorage productsStorage, IOrdersStorage ordersStorage, IRolesStorage rolesStorage)
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

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            var order = _ordersStorage.TryGetById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult OrderDetails(int id, OrderStatuses status)
        {
            var order = _ordersStorage.TryGetById(id);

            if (order != null)
            {
                order.Status = status;
            }

            return View(order);
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

        public IActionResult ProductDetails(int id)
        {
            var product = _productsStorage.TryGetById(id);

            return View(product);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _productsStorage.TryGetById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productsStorage.Update(product);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product.Price == 0)
            {
                ModelState["Price"].Errors.Clear();
                ModelState.AddModelError("Price", "Введите цену");
            }

            if (ModelState.IsValid)
            {
                _productsStorage.Add(product);

                return RedirectToAction("Products");
            }
            
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productsStorage.TryGetById(id);

            if (product != null)
            {
                _productsStorage.Remove(product);
            }

            return RedirectToAction("Products");
        }
    }
}
