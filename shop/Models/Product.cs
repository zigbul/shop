namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int _idCounter = 0;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Product(string name, decimal price, string description, string imgUrl)
        {
            Id = _idCounter;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imgUrl;

            _idCounter++;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCost: {Price}\nDescription: {Description}";
        }
    }
}
