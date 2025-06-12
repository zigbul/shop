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

        public void Add(Product product, string userId)
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
    }
}
