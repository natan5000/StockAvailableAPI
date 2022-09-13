namespace StockAvailableAPI.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string code { get; set; }
        public int quantity { get; set; }
        public Product Product { get; set; }
        public int productId { get; set; }
    }
}
