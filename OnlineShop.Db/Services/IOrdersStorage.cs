using OnlineShop.Db.Models;
using OnlineShop.Dbp.Models.Enums;

namespace OnlineShop.Db.Services
{
    public interface IOrdersStorage
    {
        void Add(Order order);

        List<Order> GetAll();

        Order? TryGetById(Guid id);

        void ChangeStatus(Guid id, OrderStatuses status);
    }
}