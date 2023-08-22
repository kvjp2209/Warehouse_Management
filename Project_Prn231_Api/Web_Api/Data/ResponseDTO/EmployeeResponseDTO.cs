namespace Web_Api.Data.ResponseDTO
{
    public class EmployeeResponseDTO
    {
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public long? AccountId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
