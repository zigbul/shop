using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public static class CartsStorage
    {
        private static List<Cart> _carts = new List<Cart>();

        public static Cart? TryGetCardByUserId(string userId)
        {
            return _carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public static void Add(Product product, string userId)
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
