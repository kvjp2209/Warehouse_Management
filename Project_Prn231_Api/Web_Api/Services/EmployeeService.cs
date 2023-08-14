﻿using AutoMapper;
using OJTMS_API.Data;
using System;
using System.Collections.Generic;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Repositories.Interfaces;
using Web_Api.Service.Interfaces;

namespace Web_Api.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateEmployee(EmployeeRequestDTO employeeRequestDTO)
        {
            try
            {
                return await _employeeRepository.CreateEmployee(employeeRequestDTO);
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
                return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EmployeeResponseDTO>> GetAllEmployees()
        {
            try
            {
                return _mapper.Map<List<EmployeeResponseDTO>>(await _employeeRepository.GetAllEmployees());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeResponseDTO> GetEmployeeById(long id)
        {
            try
            {
                return _mapper.Map<EmployeeResponseDTO>(await _employeeRepository.GetEmployeeById(id));
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
                return await _employeeRepository.UpdateEmployee(id, employeeRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}