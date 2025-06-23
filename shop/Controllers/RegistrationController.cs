using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUsersStorage _usersStorage;

        public RegistrationController(IUsersStorage usersStorage)
        {
            _usersStorage = usersStorage;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            var existingUser = _usersStorage.Get(new Auth() { Login = user.Login, Password = user.Password });

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Такой логин уже существует");
            }

            if (ModelState.IsValid == false)
            {
                return View(user);
            }

            _usersStorage.Add(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
