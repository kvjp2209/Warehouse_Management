using AutoMapper;
using Web_Api.Data;
using System;
using System.Collections.Generic;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Repositories.Interfaces;
using Web_Api.Services.Interfaces;

namespace Web_Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateSupplier(SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                return await _supplierRepository.CreateSupplier(supplierRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteSupplier(long id)
        {
            try
            {
                return await _supplierRepository.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SupplierResponseDTO>> GetAllSuppliers()
        {
            try
            {
                return _mapper.Map<List<SupplierResponseDTO>>(await _supplierRepository.GetAllSuppliers());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SupplierResponseDTO> GetSupplierByAccountId(long id)
        {
            try
            {
                return _mapper.Map<SupplierResponseDTO>(await _supplierRepository.GetSupplierByAccountId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SupplierResponseDTO> GetSupplierById(long id)
        {
            try
            {
                return _mapper.Map<SupplierResponseDTO>(await _supplierRepository.GetSupplierById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateSupplier(long id, SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                return await _supplierRepository.UpdateSupplier(id, supplierRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
