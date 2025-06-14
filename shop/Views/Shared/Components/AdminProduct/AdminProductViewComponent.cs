using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.AdminProduct
{
    public class AdminProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Product product)
        {
            return View("AdminProduct", product);
        }
    }
}
