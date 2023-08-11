using Web_Api.Models;

namespace Web_Api.Data.ResponseDTO
{
    public class ProductResponseDTO
    {
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public long WarehouseId { get; set; }

        public virtual WarehouseResponseDTO WarehouseResponseDTO { get; set; } = null!;
    }
}
