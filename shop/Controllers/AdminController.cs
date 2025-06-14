using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Properties;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(AdminMenuItems item = AdminMenuItems.Orders)
        {
            return View(item);
        }
    }
}
