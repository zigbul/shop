using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUsersStorage _usersStorage;

        public AuthorizationController(IUsersStorage usersStorage)
        {
            _usersStorage = usersStorage;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Auth auth)
        {
            var user = _usersStorage.Get(auth);

            if (user == null)
            {
                ModelState.AddModelError("", "Вы ввели неверные данные");
            }

            if (ModelState.IsValid == false)
            {
                return View(auth);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
