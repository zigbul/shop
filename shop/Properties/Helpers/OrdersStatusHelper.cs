using OnlineShopWebApp.Models.Enums;

namespace OnlineShopWebApp.Properties.Helpers
{
    public static class OrdersStatusHelper
    {
        public static readonly Dictionary<OrderStatuses, string> Statuses = new()
        {
            { OrderStatuses.Created, "Создан" },
            { OrderStatuses.Proccessing, "В обработке" },
            { OrderStatuses.Shipped, "Отправлен" },
            { OrderStatuses.Cancelled, "Отменён" },
            { OrderStatuses.Delivered, "Доставлен" },
        };
    }
}
