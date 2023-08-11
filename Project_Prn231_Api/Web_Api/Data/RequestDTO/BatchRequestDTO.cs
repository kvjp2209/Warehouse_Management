namespace Web_Api.Data.RequestDTO
{
    public class BatchRequestDTO
    {
        public long BatchId { get; set; }
        public long ProductId { get; set; }
        public int? QuantityIn { get; set; }
        public int? QuantityOut { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? ExportDate { get; set; }
        public long SupplierId { get; set; }
        public long WarehouseId { get; set; }
    }
}
