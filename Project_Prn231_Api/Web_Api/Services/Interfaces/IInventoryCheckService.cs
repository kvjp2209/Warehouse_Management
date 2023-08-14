using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Service.Interfaces
{
    public interface IInventoryCheckService
    {
        public Task<List<InventoryCheckResponseDTO>> GetAllInventoryChecks();
        public Task<InventoryCheckResponseDTO> GetInventoryCheckById(long id);
        public Task<ApiResponse> CreateInventoryCheck(InventoryCheckRequestDTO inventoryCheckRequestDTO);
        public Task<ApiResponse> UpdateInventoryCheck(long id, InventoryCheckRequestDTO inventoryCheckRequestDTO);
        public Task<ApiResponse> DeleteInventoryCheck(long id);
    }
}
