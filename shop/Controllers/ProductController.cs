using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Text.Json;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsStorage _productsStorage;

        public ProductController()
        {
            _productsStorage = new ProductsStorage();
        }

        public string Index(int id = 1)
        {
            var product = _productsStorage.TryGetById(id);

            if (product == null)
            {
                return $"Продукта с Id = {id} не существует";
            }

            return product.ToString();
        }
    }
}
