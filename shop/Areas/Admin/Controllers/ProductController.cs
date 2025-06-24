using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

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
            var product = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Price = productDb.Price,
                Description = productDb.Description,
                ImageUrl = productDb.ImageUrl,
            };

            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var productDb = _productsStorage.TryGetById(id);
            var product = new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Price = productDb.Price,
                Description = productDb.Description,
                ImageUrl = productDb.ImageUrl,
            };

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

            var productDb = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };

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

            var productDb = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };

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
