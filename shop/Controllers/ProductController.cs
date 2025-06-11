using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Text.Json;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id = 1)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "products.json");
            var json = System.IO.File.ReadAllText(filePath);

            var products = JsonSerializer.Deserialize<List<Product>>(json);

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                return $"Id: {product.Id}\nНазвание: {product.Name}\nСтоимость: {product.Cost: 0.00}\nОписание: {product.Description}";
            }
            else
            {
                return "Товара с таким id нет.";
            }
        }
    }
}
