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
    public class BatchRepository : IBatchRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public BatchRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Batch>> GetAllBatches()
        {
            try
            {
                return await _context.Batches.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Batch> GetBatchById(long id)
        {
            try
            {
                return await _context.Batches.FirstOrDefaultAsync(x => x.BatchId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateBatch(BatchRequestDTO batchRequestDTO)
        {
            try
            {
                var batch = _mapper.Map<Batch>(batchRequestDTO);
                _context.Batches!.Add(batch);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteBatch(long id)
        {
            try
            {
                var batch = GetBatchById(id).Result;
                if (batch == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                batch.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateBatch(long id, BatchRequestDTO batchRequestDTO)
        {
            try
            {
                var batch = GetBatchById(id).Result;
                if (id != batchRequestDTO.BatchId || batch == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                batch = _mapper.Map(batchRequestDTO, batch);
                _context.Update(batch);
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
