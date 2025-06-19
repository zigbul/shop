using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models.Enums
{
    public enum OrderStatuses
    {
        [Display(Name = "Создан")]
        Created,
        Proccessing,
        Shipped,
        Cancelled,
        Delivered
    }
}
