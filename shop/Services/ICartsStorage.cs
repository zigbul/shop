using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartsStorage
    {
        public Cart? TryGetCardByUserId(string userId);

        public void Add(Product product, string userId);
    }
}