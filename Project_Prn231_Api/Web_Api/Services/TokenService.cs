using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Api.Data.ResponseDTO;
using Web_Api.Services.Interfaces;

namespace Web_Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(AccountResponseDTO accountResponseDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, accountResponseDTO.AccountId.ToString()),
                new(ClaimTypes.Role, accountResponseDTO.Role)
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                _configuration["JwtToken:Issuer"],
                _configuration["JwtToken:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credential);

            return tokenHandler.WriteToken(token);
        }

        public List<Claim> ReadClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            if (securityToken == null)
                return new List<Claim>();

            return securityToken.Claims.ToList();
        }
    }
}
