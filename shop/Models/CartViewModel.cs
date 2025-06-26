namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public required Guid Id { get; set; }

        public required Guid UserId { get; set; }

        public required List<CartItemViewModel> Items { get; set; } = [];

        public decimal Cost => Items.Sum(item => item.Cost);

        public int ItemsAmount =>  Items.Sum(item => item.Amount);
    }
}
