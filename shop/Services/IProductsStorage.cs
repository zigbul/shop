using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();

        void Remove(Product product);

        public void Update(int id, string name, decimal price, string description, string imageUrl);

        public void Add(Product product);

        public Product? TryGetById(int id);
    }
}