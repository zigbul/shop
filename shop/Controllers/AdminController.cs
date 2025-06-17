using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public AdminController(IProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
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
        public IActionResult EditProduct(int id, string name, decimal price, string description, string imageUrl)
        {
            _productsStorage.Update(id, name, price, description, imageUrl);
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
