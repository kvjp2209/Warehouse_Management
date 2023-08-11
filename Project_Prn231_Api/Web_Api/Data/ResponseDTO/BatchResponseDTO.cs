using Web_Api.Models;

namespace Web_Api.Data.ResponseDTO
{
    public class BatchResponseDTO
    {
        public long BatchId { get; set; }
        public long ProductId { get; set; }
        public int? QuantityIn { get; set; }
        public int? QuantityOut { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? ExportDate { get; set; }
        public long SupplierId { get; set; }
        public long WarehouseId { get; set; }

        public virtual ProductResponseDTO ProductResponseDTO { get; set; } = null!;
        public virtual SupplierResponseDTO SupplierResponseDTO { get; set; } = null!;
        public virtual WarehouseResponseDTO WarehouseResponseDTO { get; set; } = null!;
    }
}
