using OnlineShop.Db.Models;

namespace OnlineShop.Db.Services
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();

        void Remove(Product product);

        public void Update(Product product);

        public void Add(Product product);

        public Product? TryGetById(Guid id);
    }
}