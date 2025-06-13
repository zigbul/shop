using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ICartsStorage _cartsStorage;

        public OrderController(ICartsStorage cartsStorage) 
        {
            _cartsStorage = cartsStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            _cartsStorage.RemoveCartByUserId("1");

            return View();
        }
    }
}
