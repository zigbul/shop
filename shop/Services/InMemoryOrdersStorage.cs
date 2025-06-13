using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryOrdersStorage : IOrdersStorage
    {
        private List<Cart> _orders = new List<Cart>();

        public void Add(Cart cart)
        {
            _orders.Add(cart);
        }
    }
}
