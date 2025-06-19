using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();

        void Remove(Product product);

        public void Update(Product product);

        public void Add(Product product);

        public Product? TryGetById(int id);
    }
}