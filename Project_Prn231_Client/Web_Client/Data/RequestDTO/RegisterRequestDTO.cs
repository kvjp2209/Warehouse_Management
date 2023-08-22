using System.ComponentModel.DataAnnotations;

namespace Web_Client.Data.RequestDTO
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RePassword { get; set; }
    }
}
