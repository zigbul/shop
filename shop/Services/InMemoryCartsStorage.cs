using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Services
{
    public class InMemoryCartsStorage : ICartsStorage
    {
        private List<Cart> _carts = new List<Cart>();

        public Cart? TryGetCardByUserId(string userId)
        {
            return _carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void IncreaseItemAmount(Product product, string userId)
        {
            var cart = TryGetCardByUserId(userId);

            if (cart == null)
            {
                cart = new Cart(userId);
                _carts.Add(cart);
            }


            var productInCart = cart.Items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (productInCart == null)
            {
                cart.Items.Add(new CartItem(product));
            }
            else
            {
                productInCart.Amount++;
            } 
        }

        public void DecreaseItemAmount(Guid itemId, Guid cartId)
        {
            var cart = _carts.FirstOrDefault(cart => cart.Id == cartId);
            var cartItem = cart.Items.FirstOrDefault(item => item.Id == itemId);

            cartItem.Amount--;

            if (cartItem.Amount == 0)
            {
                cart.Items = cart.Items.Where(item => item.Id != itemId).ToList();
            }

            if (cart.Items.Count == 0)
            {
                _carts = _carts.Where(cart => cart.Id != cartId).ToList();
            }
        }

        public void Remove(Cart cart)
        {
            _carts.Remove(cart);
        }
    }
}
