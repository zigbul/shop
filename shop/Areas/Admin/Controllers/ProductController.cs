using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Properties.Helpers;

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

        public IActionResult Details(Guid id)
        {
            var productDb = _productsStorage.TryGetById(id);

            if (productDb == null)
            {
                return RedirectToAction("Products", "Home");
            }

            var product = productDb.ToProductViewModel();

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var productDb = _productsStorage.TryGetById(id);

            if (productDb == null)
            {
                return RedirectToAction("Products", "Home");
            }

            var product = productDb.ToProductViewModel();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (product.Price == 0)
            {
                ModelState["Price"]?.Errors.Clear();
                ModelState.AddModelError("Price", "Введите цену");
            }

            if (ModelState.IsValid == false)
            {
                return View(product);
            }

            var productDb = product.ToProduct();

            _productsStorage.Update(productDb);

            return RedirectToAction("Products", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (product.Price == 0)
            {
                ModelState["Price"]?.Errors.Clear();
                ModelState.AddModelError("Price", "Введите цену");
            }

            if (ModelState.IsValid == false)
            {
                return View(product);
            }

            var productDb = product.ToProduct();

            _productsStorage.Add(productDb);

            return RedirectToAction("Products", "Home");
        }

        public IActionResult Remove(Guid id)
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
