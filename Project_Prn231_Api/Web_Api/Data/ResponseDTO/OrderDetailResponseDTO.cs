using Web_Api.Models;

namespace Web_Api.Data.ResponseDTO
{
    public class OrderDetailResponseDTO
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual OrderResponseDTO OrderResponseDTO { get; set; } = null!;
        public virtual ProductResponseDTO ProductResponseDTO { get; set; } = null!;
    }
}
