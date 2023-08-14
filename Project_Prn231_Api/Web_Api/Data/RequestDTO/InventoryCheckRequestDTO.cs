using Web_Api.Models;

namespace Web_Api.Data.RequestDTO
{
    public class InventoryCheckRequestDTO
    {
        public long? InventoryCheckId { get; set; }
        public DateTime? CheckDate { get; set; }
        public long WarehouseId { get; set; }
    }
}
