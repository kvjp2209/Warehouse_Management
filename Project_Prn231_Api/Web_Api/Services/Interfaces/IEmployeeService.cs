using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeResponseDTO>> GetAllEmployees();
        public Task<EmployeeResponseDTO> GetEmployeeById(long id);
        public Task<ApiResponse> CreateEmployee(EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> UpdateEmployee(long id, EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> DeleteEmployee(long id);
    }
}
