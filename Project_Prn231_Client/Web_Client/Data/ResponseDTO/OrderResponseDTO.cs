namespace Web_Client.Data.ResponseDTO
{
    public class OrderResponseDTO
    {
        public long OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalAmount { get; set; }
        public long EmployeeId { get; set; }

        public virtual EmployeeResponseDTO EmployeeResponseDTO { get; set; } = null!;
    }
}
