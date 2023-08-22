using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IBatchRepository
    {
        public Task<List<Batch>> GetAllBatches();
        public Task<Batch> GetBatchById(long id);
        public Task<ApiResponse> CreateBatch(BatchRequestDTO batchRequestDTO);
        public Task<ApiResponse> UpdateBatch(long id, BatchRequestDTO batchRequestDTO);
        public Task<ApiResponse> DeleteBatch(long id);
    }
}
