using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using shop.Models;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "products.json");
            var json = System.IO.File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(json);

            var result = "";

            foreach (var product in products)
            {
                result += $"ID: {product.Id}\n" +
                          $"Name: {product.Name}\n" +
                          $"Cost: {product.Cost}\n\n";
            }

            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
