using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesStorage _rolesStorage;

        public RoleController(IRolesStorage rolesStorage)
        {
            _rolesStorage = rolesStorage;
        }

        public IActionResult Remove(string name)
        {
            var role = _rolesStorage.TryGetByName(name);

            if (role != null)
            {
                _rolesStorage.Remove(role);
            }

            return RedirectToAction("Roles", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            var existing = _rolesStorage.TryGetByName(role.Name);

            if (existing != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }

            if (ModelState.IsValid)
            {
                _rolesStorage.Add(role);

                return RedirectToAction("Roles", "Home");
            }

            return View(role);
        }
    }
}
