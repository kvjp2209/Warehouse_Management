namespace Web_Api.Data.RequestDTO
{
    public class AccountRequestDTO
    {
        public long? AccountId { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
    }
}
