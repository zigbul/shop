using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Auth auth)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(auth);
        }
    }
}
