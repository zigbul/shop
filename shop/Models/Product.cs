using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int _idCounter = 0;

        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Введите цену продукта")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена не может быть отрицательной")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Добавьте описание продукта")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Добавьте ссылку на фото продукта")]
        public required string ImageUrl { get; set; }

        public Product()
        {
            Id = _idCounter;
            _idCounter++;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCost: {Price}\nDescription: {Description}";
        }
    }
}
