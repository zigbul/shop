using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();

        public Product? TryGetById(int id);
    }
}