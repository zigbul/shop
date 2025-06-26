using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface ICartsStorage
    {
        public Cart? TryGetCardByUserId(Guid userId);

        public void IncreaseItemAmount(Product product);

        public void DecreaseItemAmount(Guid itemId, Guid cartId);

        public void Remove(Cart cart);
    }
}