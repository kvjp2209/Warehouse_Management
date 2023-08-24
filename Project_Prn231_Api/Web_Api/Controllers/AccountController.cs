using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Models;
using Web_Api.Services.Interfaces;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var response = await _accountService.GetAllAccounts();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Supplier")]
        [Authorize(Roles = "Supplier")]
        public async Task<IActionResult> GetAllSupplierAccounts()
        {
            try
            {
                var response = await _accountService.GetAllSupplierAccounts();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Employee")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetAllEmployeeAccounts()
        {
            try
            {
                var response = await _accountService.GetAllEmployeeAccounts();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAccountById(long id)
        {
            try
            {
                var response = await _accountService.GetAccountById(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(AccountRequestDTO accountRequestDTO)
        {
            try
            {
                var response = await _accountService.CreateAccount(accountRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Employee,Supplier,Admin")]
        public async Task<IActionResult> UpdateAccount(long id, AccountRequestDTO accountRequestDTO)
        {
            try
            {
                var response = await _accountService.UpdateAccount(id, accountRequestDTO);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Employee,Supplier,Admin")]
        public async Task<IActionResult> DeleteAccount(long id)
        {
            try
            {
                var response = await _accountService.DeleteAccount(id);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            //var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            var user = await _accountService.GetAccountByUsername(login.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var pass = login.Password.Equals(user.Password);
            if (pass)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:NotTokenKeyForSureSourceTrustMeDude"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(
                    _configuration["JwtToken:Issuer"],
                    _configuration["JwtToken:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                    );
                var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
                Response.Cookies.Append("jwtToken", new JwtSecurityTokenHandler().WriteToken(token));

                return Ok(new LoginResponseDTO { Successful = true, Token = tokenHandler, Role = user.Role, UserId = user.AccountId });
            }

            return BadRequest("Invalid login attempt.");
        }

        // GET api/<AccountController>/5
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDTO registerRequestDTO)
        {
            if (!registerRequestDTO.RePassword.Equals(registerRequestDTO.Password))
            {
                return BadRequest("Repassword not match");
            }
            var account = new AccountRequestDTO
            {
                Username = registerRequestDTO.Username,
                Password = registerRequestDTO.Password,
                Role = "Supplier"
            };
            var result = await _accountService.CreateAccount(account);
            
            if (result.IsSuccess)
            {
                return Ok(new ApiResponse { IsSuccess = true, Message = "Successed" });
            }
            return BadRequest(new ApiResponse { IsSuccess = false, Message = "Failed!! Username Existed!!!" });
        }

        // POST api/<AccountController>
        /*[HttpDelete("Logout")]
        public async Task<IActionResult> LogoutAsync([FromBody] string value)
        {
            await _signInManager.SignOutAsync();
            return Ok(new ApiResponse { IsSuccess = true, Message = "Success" });
        }*/
    }
}
