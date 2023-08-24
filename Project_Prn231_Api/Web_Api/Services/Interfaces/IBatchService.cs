using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IBatchService
    {
        public Task<List<BatchResponseDTO>> GetAllBatches();
        public Task<BatchResponseDTO> GetBatchById(long id);
        public Task<ApiResponse> CreateBatch(BatchRequestDTO batchRequestDTO);
        public Task<ApiResponse> UpdateBatch(long id, BatchRequestDTO batchRequestDTO);
        public Task<ApiResponse> DeleteBatch(long id);
        public Task<List<BatchResponseDTO>> GetBatchBySupplierId(long id);
    }
}
