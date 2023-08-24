namespace Web_Client.Data.ResponseDTO
{
    public class LoginResponseDTO
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public long? UserId { get; set; }
        public long? AccountId { get; set; }
        public string Token { get; set; }
        public String Role { get; set; }
    }
}
