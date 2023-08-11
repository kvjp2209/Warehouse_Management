namespace Web_Api.Data.RequestDTO
{
    public class EmployeeRequestDTO
    {
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
