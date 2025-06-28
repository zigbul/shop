using OnlineShop.Db.Models;

namespace OnlineShop.Db.Services
{
    public class DbProductsStorage : IProductsStorage
    {
        private readonly DatabaseContext _dbContext;

        public DbProductsStorage(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public void Remove(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public void Update(Product editedProduct)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == editedProduct.Id);

            if (product != null)
            {
                product.Name = editedProduct.Name;
                product.Price = editedProduct.Price;
                product.Description = editedProduct.Description;
                product.ImageUrl = editedProduct.ImageUrl;
            }

            _dbContext.SaveChanges();
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public Product? TryGetById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(product => product.Id == id);
        }
    }
}
