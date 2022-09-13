namespace StockAvailableAPI.Models
{
    public class productDetails
    {
        public int Id { get; set; } 
        public string code { get; set; }
        public DateTime date_last { get; set; }
        public int stock { get; set; }
    }
}
