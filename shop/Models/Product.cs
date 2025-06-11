namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int _idCounter = 0;

        public int Id { get; }

        public string Name { get; }

        public decimal Cost { get; }

        public string Description { get; }

        public Product(string name, decimal cost, string description)
        {
            Id = _idCounter;
            Name = name;
            Cost = cost;
            Description = description;

            _idCounter++;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nCost: {Cost}\nDescription: {Description}";
        }
    }
}
