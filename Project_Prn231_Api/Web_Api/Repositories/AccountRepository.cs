using AutoMapper;
using Web_Api.Data;
using Microsoft.EntityFrameworkCore;
using Web_Api.Commons;
using Web_Api.Models;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Repositories.Interfaces;

namespace Web_Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public AccountRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            try
            {
                return await _context.Accounts.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetAccountById(long id)
        {
            try
            {
                return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> GetAccountByUserName(string userName)
        {
            try
            {
                return await _context.Accounts.FirstOrDefaultAsync(x => x.Username == userName && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateAccount(AccountRequestDTO accountRequestDTO)
        {
            try
            {
                if (IsUserNameExisted(accountRequestDTO).Result)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.USER_NAME_EXISTED };
                }
                var account = _mapper.Map<Account>(accountRequestDTO);
                _context.Accounts!.Add(account);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS, Content = account.AccountId };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteAccount(long id)
        {
            try
            {
                var account = GetAccountById(id).Result;
                if (account == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                account.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAccount(long id, AccountRequestDTO accountRequestDTO)
        {
            try
            {
                var account = GetAccountById(id).Result;
                if (id != accountRequestDTO.AccountId || account == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                if (IsUserNameExisted(accountRequestDTO).Result)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.USER_NAME_EXISTED };
                }
                account = _mapper.Map(accountRequestDTO, account);
                _context.Update(account);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsUserNameExisted(AccountRequestDTO accountRequestDTO)
        {
            try
            {
                return await _context.Accounts.AnyAsync(x => x.Username.Equals(accountRequestDTO.Username) && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
