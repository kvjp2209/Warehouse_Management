using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Service.Interfaces
{
    public interface IWarehouseService
    {
        public Task<List<WarehouseResponseDTO>> GetAllWarehouses();
        public Task<WarehouseResponseDTO> GetWarehouseById(long id);
        public Task<ApiResponse> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO);
        public Task<ApiResponse> UpdateWarehouse(long id, WarehouseRequestDTO warehouseRequestDTO);
        public Task<ApiResponse> DeleteWarehouse(long id);
    }
}
