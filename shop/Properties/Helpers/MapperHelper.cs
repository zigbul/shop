using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Properties.Helpers
{
    public static class MapperHelper
    {
        public static Product ToProduct(this ProductViewModel product)
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

        public static ProductViewModel ToProductViewModel(this Product product)
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

        public static List<ProductViewModel> ToProductViewModel(this List<Product> products)
        {
            var productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = product.ToProductViewModel();
                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public static CartViewModel? ToCartViewModel(this Cart? cart)
        {
            if (cart == null) return null;

            return new CartViewModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.ToCartItemViewModel()
            };
        }

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            return new CartItemViewModel()
            {
                Id = cartItem.Id,
                Product = cartItem.Product.ToProductViewModel(),
                Amount = cartItem.Amount
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModel(this List<CartItem> cartItems)
        {
            var cartItemViewModels = new List<CartItemViewModel>();

            foreach (var cartItem in cartItems)
            {
                var cartItemViewModel = cartItem.ToCartItemViewModel();
                cartItemViewModels.Add(cartItemViewModel);
            }

            return cartItemViewModels;
        }

        public static OrderItemViewModel ToOrderItemViewModel(this OrderItem orderItem)
        {
            return new OrderItemViewModel()
            {
                Id = orderItem.Id,
                Amount = orderItem.Amount,
                Product = orderItem.Product.ToProductViewModel(),
            };
        }

        public static List<OrderItemViewModel> ToOrderItemViewModel(this List<OrderItem> orderItems)
        {
            var orderItemViewModels = new List<OrderItemViewModel>();

            foreach (var orderItem in orderItems)
            {
                var orderItemViewModel = orderItem.ToOrderItemViewModel();
                orderItemViewModels.Add(orderItemViewModel);
            }

            return orderItemViewModels;
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Email = order.Email,
                Phone = order.Phone,
                Status = order.Status,
                Date = order.Date,
                Items = order.Items.ToOrderItemViewModel()
            };
        }

        public static List<OrderViewModel> ToOrderViewModel(this List<Order> orders)
        {
            var orderViewModels = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderViewModel = order.ToOrderViewModel();
                orderViewModels.Add(orderViewModel);
            }

            return orderViewModels;
        }
    }
}
