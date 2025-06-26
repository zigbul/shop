using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Properties.Helpers
{
    public static class MapperHelper
    {
        public static Product ToProduct(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
            };
        }

        public static List<ProductViewModel> ToProductViewModel(List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = ToProductViewModel(product);
                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null) return null;

            return new CartViewModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModel(cart.Items)
            };
        }

        public static CartItemViewModel ToCartItemViewModel(CartItem cartItem)
        {
            return new CartItemViewModel()
            {
                Id = cartItem.Id,
                Product = ToProductViewModel(cartItem.Product),
                Amount = cartItem.Amount
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModel(List<CartItem> cartItems)
        {
            var cartItemViewModels = new List<CartItemViewModel>();

            foreach (var cartItem in cartItems)
            {
                var cartItemViewModel = ToCartItemViewModel(cartItem);
                cartItemViewModels.Add(cartItemViewModel);
            }

            return cartItemViewModels;
        }
    }
}
