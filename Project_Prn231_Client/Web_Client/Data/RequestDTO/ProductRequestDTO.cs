namespace Web_Client.Data.RequestDTO
{
    public class ProductRequestDTO
    {
        public long? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public long WarehouseId { get; set; }
    }
}
