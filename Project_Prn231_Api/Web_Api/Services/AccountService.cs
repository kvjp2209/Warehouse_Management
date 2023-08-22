using AutoMapper;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Repositories.Interfaces;
using Web_Api.Services.Interfaces;

namespace Web_Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, ITokenService tokenService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse> CreateAccount(AccountRequestDTO accountRequestDTO)
        {
            try
            {
                return await _accountRepository.CreateAccount(accountRequestDTO);
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
                return await _accountRepository.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountResponseDTO> GetAccountById(long id)
        {
            try
            {
                return _mapper.Map<AccountResponseDTO>(await _accountRepository.GetAccountById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountResponseDTO> GetAccountByUsername(string userName)
        {
            try
            {
                return _mapper.Map<AccountResponseDTO>(await _accountRepository.GetAccountByUserName(userName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountResponseDTO>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountRepository.GetAllAccounts();
                return _mapper.Map<List<AccountResponseDTO>>(accounts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountResponseDTO>> GetAllSupplierAccounts()
        {
            try
            {
                var accounts = _accountRepository.GetAllAccounts().Result.Where(x => x.Role == "Supplier").ToList();
                return _mapper.Map<List<AccountResponseDTO>>(accounts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountResponseDTO>> GetAllEmployeeAccounts()
        {
            try
            {
                var accounts = _accountRepository.GetAllAccounts().Result.Where(x => x.Role == "Employee").ToList();
                return _mapper.Map<List<AccountResponseDTO>>(accounts);
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
                return await _accountRepository.UpdateAccount(id, accountRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
