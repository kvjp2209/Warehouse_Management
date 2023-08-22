using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccounts();
        public Task<Account> GetAccountById(long id);
        public Task<Account> GetAccountByUserName(string userName);
        public Task<ApiResponse> CreateAccount(AccountRequestDTO accountRequestDTO);
        public Task<ApiResponse> UpdateAccount(long id, AccountRequestDTO accountRequestDTO);
        public Task<ApiResponse> DeleteAccount(long id);
    }
}
