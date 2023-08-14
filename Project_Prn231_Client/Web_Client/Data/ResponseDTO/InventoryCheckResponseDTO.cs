namespace Web_Client.Data.ResponseDTO
{
    public class InventoryCheckResponseDTO
    {
        public long InventoryCheckId { get; set; }
        public DateTime? CheckDate { get; set; }
        public long WarehouseId { get; set; }

        public virtual WarehouseResponseDTO WarehouseResponseDTO { get; set; } = null!;
    }
}
