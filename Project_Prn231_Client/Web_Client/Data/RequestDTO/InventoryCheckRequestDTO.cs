namespace Web_Client.Data.RequestDTO
{
    public class InventoryCheckRequestDTO
    {
        public long? InventoryCheckId { get; set; }
        public DateTime? CheckDate { get; set; }
        public long WarehouseId { get; set; }
    }
}
