using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeResponseDTO>> GetAllEmployees();
        public Task<EmployeeResponseDTO> GetEmployeeById(long id);
        public Task<ApiResponse> CreateEmployee(EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> UpdateEmployee(long id, EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> DeleteEmployee(long id);
        public Task<EmployeeResponseDTO> GetEmployeeByAccountId(long id);
    }
}
