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
    public class InventoryCheckService : IInventoryCheckService
    {
        private readonly IInventoryCheckRepository _inventoryCheckRepository;
        private readonly IMapper _mapper;

        public InventoryCheckService(IInventoryCheckRepository inventoryCheckRepository, IMapper mapper)
        {
            _inventoryCheckRepository = inventoryCheckRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateInventoryCheck(InventoryCheckRequestDTO inventoryCheckRequestDTO)
        {
            try
            {
                return await _inventoryCheckRepository.CreateInventoryCheck(inventoryCheckRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteInventoryCheck(long id)
        {
            try
            {
                return await _inventoryCheckRepository.DeleteInventoryCheck(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<InventoryCheckResponseDTO>> GetAllInventoryChecks()
        {
            try
            {
                return _mapper.Map<List<InventoryCheckResponseDTO>>(await _inventoryCheckRepository.GetAllInventoryChecks());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InventoryCheckResponseDTO> GetInventoryCheckById(long id)
        {
            try
            {
                return _mapper.Map<InventoryCheckResponseDTO>(await _inventoryCheckRepository.GetInventoryCheckById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateInventoryCheck(long id, InventoryCheckRequestDTO inventoryCheckRequestDTO)
        {
            try
            {
                return await _inventoryCheckRepository.UpdateInventoryCheck(id, inventoryCheckRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
