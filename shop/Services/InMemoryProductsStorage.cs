using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryProductsStorage : IProductsStorage
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Хлеб", 55, "Свежий, душистый каравай — основа крестьянского рациона. Скромный, но спасает от голода."),
            new Product("Сыр", 125, "Выдержанный, ароматный ломоть — пища аристократов и мышей. Дарует силу и удовольствие."),
            new Product("Молоко", 78, "Свежее, парящее молоко — источник жизни и магической силы. Пейте, смертные!"),
            new Product("Яйцо", 109, "Символ жизни, смерти на сковородке и возрождения в салате."),
            new Product("Шоколад", 250, "Тёмная алхимия какао-бобов, растопляющая сердца и волю. Запретный плод сладкоежек.")
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product? TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
