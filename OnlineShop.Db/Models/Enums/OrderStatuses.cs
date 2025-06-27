using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Dbp.Models.Enums
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
