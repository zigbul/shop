using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string login, string password, bool isRemembered)
        {
            return RedirectToAction("Index");
        }
    }
}
