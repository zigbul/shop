using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsStorage _productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IActionResult Details(int id)
        {
            var product = _productsStorage.TryGetById(id);

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productsStorage.TryGetById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (product.Price == 0)
            {
                ModelState["Price"]?.Errors.Clear();
                ModelState.AddModelError("Price", "Введите цену");
            }

            if (ModelState.IsValid)
            {
                _productsStorage.Update(product);

                return RedirectToAction("Products", "Home");
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product.Price == 0)
            {
                ModelState["Price"]?.Errors.Clear();
                ModelState.AddModelError("Price", "Введите цену");
            }

            if (ModelState.IsValid)
            {
                _productsStorage.Add(product);

                return RedirectToAction("Products", "Home");
            }
            
            return View(product);
        }

        public IActionResult Remove(int id)
        {
            var product = _productsStorage.TryGetById(id);

            if (product != null)
            {
                _productsStorage.Remove(product);
            }

            return RedirectToAction("Products", "Home");
        }
    }
}
