using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Хлеб",
                    Price = 55,
                    Description = "Свежий, душистый каравай — основа крестьянского рациона. Скромный, но спасает от голода.",
                    ImageUrl = "/images/bread.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Сыр",
                    Price = 125,
                    Description = "Выдержанный, ароматный ломоть — пища аристократов и мышей. Дарует силу и удовольствие.",
                    ImageUrl = "/images/cheese.png"
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Молоко",
                    Price = 78,
                    Description = "Свежее, парящее молоко — источник жизни и магической силы. Пейте, смертные!",
                    ImageUrl = "/images/milk.png"
                },
                new Product() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Яйцо",
                    Price = 109,
                    Description = "Символ жизни, смерти на сковородке и возрождения в салате.",
                    ImageUrl = "/images/egg.png"
                },
                new Product()  
                {
                    Id = Guid.NewGuid(),
                    Name = "Шоколад",
                    Price = 250,
                    Description = "Тёмная алхимия какао-бобов, растопляющая сердца и волю. Запретный плод сладкоежек.",
                    ImageUrl = "/images/chocolate.png"
                }
            });
        }
    }
}
