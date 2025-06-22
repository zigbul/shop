using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersStorage _usersStorage;

        public UserController(IUsersStorage usersStorage) 
        {
            _usersStorage = usersStorage;
        }

        public IActionResult Details(Guid id)
        {
            var user = _usersStorage.GetById(id);

            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("Users", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword(Guid id)
        {
            var pass = new Pass() { Id = id };

            return View(pass);
        }

        [HttpPost]
        public IActionResult ChangePassword(Pass pass)
        {
            var user = _usersStorage.GetById(pass.Id);

            if (user == null)
            {
                return RedirectToAction("Users", "Home");
            }
            else if (user.Password != pass.OldPassword)
            {
                ModelState.AddModelError(nameof(pass.OldPassword), "Неверный пароль");
            }

            if (ModelState.IsValid == false)
            {
                return View(pass);
            }

            if (pass.NewPassword != null && pass.ConfirmNewPassword != null)
            {
                user.Password = pass.NewPassword;
                user.ConfirmPassword = pass.ConfirmNewPassword;
            }

            return RedirectToAction(nameof(Details), new { pass.Id });
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = _usersStorage.GetById(id);

            if (user != null)
            {
                var userInfo = new UserInfo()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Login = user.Login,
                    Email = user.Email,
                    Phone = user.Phone
                };

                return View(userInfo);
            }

            return RedirectToAction("Users", "Home");
        }

        [HttpPost]
        public IActionResult Edit(UserInfo userInfo)
        {
            if (ModelState.IsValid == false)
            {
                return View(userInfo);
            }

            var user = _usersStorage.GetById(userInfo.Id);

            if (user == null)
            {
                return RedirectToAction("Users", "Home");
            }

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Login = userInfo.Login;
            user.Email = userInfo.Email;
            user.Phone = userInfo.Phone;

            return RedirectToAction("Details", new { userInfo.Id });
        }
    }
}
