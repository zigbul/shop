namespace OnlineShopWebApp.Models
{
    public class OrderItemViewModel
    {
        public required Guid Id { get; set; }
        public required ProductViewModel Product { get; set; }
        public required int Amount { get; set; }
        public decimal Cost => Amount * Product.Price;
    }
}