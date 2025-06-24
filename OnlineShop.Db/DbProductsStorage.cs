using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DbProductsStorage : IProductsStorage
    {
        private readonly DatabaseContext _dbContext;

        public DbProductsStorage(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        /*private List<Product> _products = new List<Product>()
        {
            new Product()
            { 
                Name = "Хлеб",
                Price = 55,
                Description = "Свежий, душистый каравай — основа крестьянского рациона. Скромный, но спасает от голода.",
                ImageUrl = "/images/bread.png"
            },
            new Product()
            {
                Name = "Сыр",
                Price = 125,
                Description = "Выдержанный, ароматный ломоть — пища аристократов и мышей. Дарует силу и удовольствие.",
                ImageUrl = "/images/cheese.png"
            },
            new Product()
                        {
                Name = "Молоко",
                Price = 78,
                Description = "Свежее, парящее молоко — источник жизни и магической силы. Пейте, смертные!",
                ImageUrl = "/images/milk.png"
            },
              new Product()                      {
                Name = "Яйцо",
                Price = 109,
                Description = "Символ жизни, смерти на сковородке и возрождения в салате.",
                ImageUrl = "/images/egg.png"
            },
               new Product()                                 {
                Name = "Шоколад",
                Price = 250,
                Description = "Тёмная алхимия какао-бобов, растопляющая сердца и волю. Запретный плод сладкоежек.",
                ImageUrl = "/images/chocolate.png"
            }
        };*/

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
