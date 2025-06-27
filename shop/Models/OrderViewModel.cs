using OnlineShop.Dbp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public required string Name {  get; set; }
        [Required(ErrorMessage = "Укажите адрес доставки")]
        public required string Address { get; set; }
        [Required(ErrorMessage = "Укажите ваш email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Введите телефон для связи")]
        [Phone(ErrorMessage = "Введите номер в формате +7 123 456 78 90")]
        public required string Phone { get; set; }
        public OrderStatuses Status { get; set; } = OrderStatuses.Created;
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Cost => Items.Sum(item =>  item.Cost);
        public List<OrderItemViewModel> Items { get; set; } = [];
    }
}
