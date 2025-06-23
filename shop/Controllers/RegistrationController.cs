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
            if (ModelState.IsValid)
            {
                _usersStorage.Add(user);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}
