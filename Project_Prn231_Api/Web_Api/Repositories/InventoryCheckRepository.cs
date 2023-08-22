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
    public class InventoryCheckRepository : IInventoryCheckRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public InventoryCheckRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InventoryCheck>> GetAllInventoryChecks()
        {
            try
            {
                return await _context.InventoryChecks
                    .Include(x => x.Warehouse)
                    .Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InventoryCheck> GetInventoryCheckById(long id)
        {
            try
            {
                return await _context.InventoryChecks
                    .Include(x => x.Warehouse).FirstOrDefaultAsync(x => x.InventoryCheckId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateInventoryCheck(InventoryCheckRequestDTO inventoryCheckRequestDTO)
        {
            try
            {
                var inventoryCheck = _mapper.Map<InventoryCheck>(inventoryCheckRequestDTO);
                _context.InventoryChecks!.Add(inventoryCheck);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var inventoryCheck = GetInventoryCheckById(id).Result;
                if (inventoryCheck == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                inventoryCheck.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var inventoryCheck = GetInventoryCheckById(id).Result;
                if (id != inventoryCheckRequestDTO.InventoryCheckId || inventoryCheck == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                inventoryCheck = _mapper.Map(inventoryCheckRequestDTO, inventoryCheck);
                _context.Update(inventoryCheck);
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
