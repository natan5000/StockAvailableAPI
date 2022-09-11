namespace StockAvailableAPI.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string codeBox { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        public TypeOperation TypeOperation { get; set; }
        public int typeOperationID { get; set; }
    }
}
