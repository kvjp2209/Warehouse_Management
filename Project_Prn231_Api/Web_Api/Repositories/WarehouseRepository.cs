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
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public WarehouseRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            try
            {
                return await _context.Warehouses.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Warehouse> GetWarehouseById(long id)
        {
            try
            {
                return await _context.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO)
        {
            try
            {
                var warehouse = _mapper.Map<Warehouse>(warehouseRequestDTO);
                _context.Warehouses!.Add(warehouse);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var warehouse = GetWarehouseById(id).Result;
                if (warehouse == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                warehouse.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var warehouse = GetWarehouseById(id).Result;
                if (id != warehouseRequestDTO.WarehouseId || warehouse == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                warehouse = _mapper.Map(warehouseRequestDTO, warehouse);
                _context.Update(warehouse);
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
