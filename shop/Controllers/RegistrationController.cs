using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string login, string password, string confirmPassword)
        {
            return RedirectToAction("Index");
        }
    }
}
