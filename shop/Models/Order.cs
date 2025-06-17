using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
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

        [BindNever]
        public Cart? Cart { get; set; }
    }
}
