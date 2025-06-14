using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();

        void Remove(Product product);

        public Product? TryGetById(int id);
    }
}