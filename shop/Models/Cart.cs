namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public decimal Cost => Items.Sum(item => item.Cost);

        public int ItemsAmount =>  Items.Sum(item => item.Amount);

        public Cart(string userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<CartItem>();
        }
    }
}
