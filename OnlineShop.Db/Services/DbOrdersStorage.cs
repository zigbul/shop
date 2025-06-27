using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Dbp.Models.Enums;

namespace OnlineShop.Db.Services
{
    public class DbOrdersStorage : IOrdersStorage
    {
        private readonly DatabaseContext _dbContext;

        public DbOrdersStorage(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public Order? TryGetById(Guid id)
        {
            return _dbContext.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public void ChangeStatus(Guid id, OrderStatuses status)
        {
            var order = _dbContext.Orders.Find(id);

            if (order != null)
            {
                order.Status = status;
            }

            _dbContext.SaveChanges();
        }
    }
}
