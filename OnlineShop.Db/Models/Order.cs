using OnlineShop.Dbp.Models.Enums;
using System.Net;
namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public required string Name {  get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public OrderStatuses Status { get; set; } = OrderStatuses.Created;
        public DateTime Date { get; set; } = DateTime.Now;

        public List<OrderItem> Items { get; set; } = [];

    }
}
