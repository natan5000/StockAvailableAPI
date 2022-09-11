namespace StockAvailableAPI.Models
{
    public class TypeOperation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TypeOperation> typeOperations { get; set; }
    }
}
