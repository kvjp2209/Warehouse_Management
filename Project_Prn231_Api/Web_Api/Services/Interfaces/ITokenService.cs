using System.Security.Claims;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(AccountResponseDTO accountResponseDTO);
        public List<Claim> ReadClaimsFromToken(string token);
    }
}
