using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Shared.Components.AdminProducts
{
    public class AdminProductsViewComponent : ViewComponent
    {
        private readonly IProductsStorage _productsStorage;

        public AdminProductsViewComponent(IProductsStorage productsStorage)
        {
            _productsStorage = productsStorage;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productsStorage.GetAll();

            return View("AdminProducts", products);
        }
    }
}
