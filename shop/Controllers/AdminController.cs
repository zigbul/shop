using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Properties;
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

        public IActionResult Index(AdminMenuItems item = AdminMenuItems.Orders)
        {
            return View(item);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productsStorage.TryGetById(id);

            if (product != null)
            {
                _productsStorage.Remove(product);
            }

            return RedirectToAction("Index", new { Item = AdminMenuItems.Products });
        }
    }
}
