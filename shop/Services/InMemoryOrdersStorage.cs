using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryOrdersStorage : IOrdersStorage
    {
        private List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order? TryGetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
