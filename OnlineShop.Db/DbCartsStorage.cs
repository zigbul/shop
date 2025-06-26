using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DbCartsStorage : ICartsStorage
    {
        private readonly DatabaseContext _dbContext;

        public DbCartsStorage(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cart? TryGetCardByUserId(Guid userId)
        {
            return _dbContext.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(cart => cart.UserId == userId);
        }

        public void IncreaseItemAmount(Product product)
        {
            var userId = Guid.Parse("5c18c843-52c5-455d-b44f-bec0913d047d");
            var cart = TryGetCardByUserId(userId);

            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                };

                _dbContext.Carts.Add(cart);
            }

            var productInCart = cart.Items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (productInCart == null)
            {
                cart.Items.Add(new CartItem() 
                { 
                    Product = product, 
                    Amount = 1,
                    Cart = cart,
                });
            }
            else
            {
                productInCart.Amount++;
            }

            _dbContext.SaveChanges();
        }

        public void DecreaseItemAmount(Guid itemId, Guid cartId)
        {
            var cart = _dbContext.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(cart => cart.Id == cartId);

            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Items.FirstOrDefault(item => item.Id == itemId);

            if (cartItem == null)
            {
                return;
            }

            cartItem.Amount--;

            if (cartItem.Amount == 0)
            {
                cart.Items.Remove(cartItem);
            }

            if (cart.Items.Count == 0)
            {
                _dbContext.Carts.Remove(cart);
            }

            _dbContext.SaveChanges();
        }

        public void Remove(Cart cart)
        {
            _dbContext.Carts.Remove(cart);
            _dbContext.SaveChanges();
        }
    }
}
