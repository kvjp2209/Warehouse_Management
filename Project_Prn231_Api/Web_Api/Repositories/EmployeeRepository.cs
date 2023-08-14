using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OJTMS_API.Data;
using System;
using System.Collections.Generic;
using Web_Api.Commons;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;
using Web_Api.Repositories.Interfaces;

namespace Web_Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Employees.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> GetEmployeeById(long id)
        {
            try
            {
                return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateEmployee(EmployeeRequestDTO employeeRequestDTO)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeRequestDTO);
                _context.Employees!.Add(employee);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteEmployee(long id)
        {
            try
            {
                var employee = GetEmployeeById(id).Result;
                if (employee == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                employee.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateEmployee(long id, EmployeeRequestDTO employeeRequestDTO)
        {
            try
            {
                var employee = GetEmployeeById(id).Result;
                if (id != employeeRequestDTO.EmployeeId || employee == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                employee = _mapper.Map(employeeRequestDTO, employee);
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
