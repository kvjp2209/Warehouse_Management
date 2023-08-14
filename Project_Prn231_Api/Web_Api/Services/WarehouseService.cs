using AutoMapper;
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
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                return await _warehouseRepository.CreateWarehouse(warehouseRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteWarehouse(long id)
        {
            try
            {
                return await _warehouseRepository.DeleteWarehouse(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<WarehouseResponseDTO>> GetAllWarehouses()
        {
            try
            {
                return _mapper.Map<List<WarehouseResponseDTO>>(await _warehouseRepository.GetAllWarehouses());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<WarehouseResponseDTO> GetWarehouseById(long id)
        {
            try
            {
                return _mapper.Map<WarehouseResponseDTO>(await _warehouseRepository.GetWarehouseById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateWarehouse(long id, WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                return await _warehouseRepository.UpdateWarehouse(id, warehouseRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
