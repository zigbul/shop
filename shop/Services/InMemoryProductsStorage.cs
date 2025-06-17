using AspNetCoreGeneratedDocument;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryProductsStorage : IProductsStorage
    {
        private List<Product> _products = new List<Product>()
        {
            new Product("Хлеб", 55, "Свежий, душистый каравай — основа крестьянского рациона. Скромный, но спасает от голода.", "/images/bread.png"),
            new Product("Сыр", 125, "Выдержанный, ароматный ломоть — пища аристократов и мышей. Дарует силу и удовольствие.", "/images/cheese.png"),
            new Product("Молоко", 78, "Свежее, парящее молоко — источник жизни и магической силы. Пейте, смертные!", "/images/milk.png"),
            new Product("Яйцо", 109, "Символ жизни, смерти на сковородке и возрождения в салате.", "/images/egg.png"),
            new Product("Шоколад", 250, "Тёмная алхимия какао-бобов, растопляющая сердца и волю. Запретный плод сладкоежек.", "/images/chocolate.png")
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public void Update(int id, string name, decimal price, string description, string imageUrl)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.Description = description;
                product.ImageUrl = imageUrl;
            }
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product? TryGetById(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }
    }
}
