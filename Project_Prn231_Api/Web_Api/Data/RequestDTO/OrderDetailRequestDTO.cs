namespace Web_Api.Data.RequestDTO
{
    public class OrderDetailRequestDTO
    {
        public long? OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
