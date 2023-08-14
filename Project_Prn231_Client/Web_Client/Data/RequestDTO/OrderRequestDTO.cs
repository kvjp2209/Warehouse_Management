namespace Web_Client.Data.RequestDTO
{
    public class OrderRequestDTO
    {
        public long? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalAmount { get; set; }
        public long EmployeeId { get; set; }
    }
}
