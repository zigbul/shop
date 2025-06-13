using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public interface ICartsStorage
    {
        public Cart? TryGetCardByUserId(string userId);

        public void IncreaseItemAmount(Product product, string userId);

        public void DecreaseItemAmount(Guid itemId, Guid cartId);

        public void RemoveCartByUserId(string userId);
    }
}