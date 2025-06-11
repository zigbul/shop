namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public List<Position> Positions;

        public Cart() 
        {
            Positions = new List<Position>();
        }
    }
}
