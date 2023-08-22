using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<List<AccountResponseDTO>> GetAllAccounts(); 
        public Task<List<AccountResponseDTO>> GetAllSupplierAccounts();
        public Task<List<AccountResponseDTO>> GetAllEmployeeAccounts();
        public Task<AccountResponseDTO> GetAccountById(long id);
        public Task<AccountResponseDTO> GetAccountByUsername(string username);
        public Task<ApiResponse> CreateAccount(AccountRequestDTO accountRequestDTO);
        public Task<ApiResponse> UpdateAccount(long id, AccountRequestDTO accountRequestDTO);
        public Task<ApiResponse> DeleteAccount(long id);
    }
}
