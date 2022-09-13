namespace StockAvailableAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string code  { get; set; }
        public string name { get; set; }
        public int active { get; set; }
        public List<Box> Boxes { get; set; }

    }
}
