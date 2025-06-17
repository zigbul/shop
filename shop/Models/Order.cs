using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShopWebApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int _idCounter = 1;

        public int Id { get; set; }

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

        public OrderStatuses Status { get; set; }

        public string TranslatedStatus
        {
            get {
                switch (Status)
                {
                    case OrderStatuses.Created: return "Создан";
                    case OrderStatuses.Proccessing: return "В обработке";
                    case OrderStatuses.Shipped: return "Отправлен";
                    case OrderStatuses.Cancelled: return "Отменён";
                    case OrderStatuses.Delivered: return "Доставлен";
                    default: return "Неизвестно";
                }
            }
        } 

        public DateTime Date { get; set; }

        public Order()
        {
            Id = _idCounter;
            Date = DateTime.Now;
            Status = OrderStatuses.Created;

            _idCounter++;
        }
    }
}
