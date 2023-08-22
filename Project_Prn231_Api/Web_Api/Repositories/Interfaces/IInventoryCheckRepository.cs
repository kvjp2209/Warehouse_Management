using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IInventoryCheckRepository
    {
        public Task<List<InventoryCheck>> GetAllInventoryChecks();
        public Task<InventoryCheck> GetInventoryCheckById(long id);
        public Task<ApiResponse> CreateInventoryCheck(InventoryCheckRequestDTO inventoryCheckRequestDTO);
        public Task<ApiResponse> UpdateInventoryCheck(long id, InventoryCheckRequestDTO inventoryCheckRequestDTO);
        public Task<ApiResponse> DeleteInventoryCheck(long id);
    }
}
