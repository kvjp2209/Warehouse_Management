using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployeeById(long id);
        public Task<ApiResponse> CreateEmployee(EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> UpdateEmployee(long id, EmployeeRequestDTO employeeRequestDTO);
        public Task<ApiResponse> DeleteEmployee(long id);
    }
}
