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
    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public BatchService(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateBatch(BatchRequestDTO batchRequestDTO)
        {
            try
            {
                return await _batchRepository.CreateBatch(batchRequestDTO);
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
                return await _batchRepository.DeleteBatch(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BatchResponseDTO>> GetAllBatches()
        {
            try
            {
                return _mapper.Map<List<BatchResponseDTO>>(await _batchRepository.GetAllBatches());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BatchResponseDTO> GetBatchById(long id)
        {
            try
            {
                return _mapper.Map<BatchResponseDTO>(await _batchRepository.GetBatchById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BatchResponseDTO>> GetBatchBySupplierId(long id)
        {
            try
            {
                var batchs = await _batchRepository.GetAllBatches();
                batchs = batchs.Where(x => x.SupplierId == id).ToList();
                return _mapper.Map<List<BatchResponseDTO>>(batchs);
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
                return await _batchRepository.UpdateBatch(id, batchRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
