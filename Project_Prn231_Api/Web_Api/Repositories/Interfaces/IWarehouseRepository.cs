using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {
        public Task<List<Warehouse>> GetAllWarehouses();
        public Task<Warehouse> GetWarehouseById(long id);
        public Task<ApiResponse> CreateWarehouse(WarehouseRequestDTO warehouseRequestDTO);
        public Task<ApiResponse> UpdateWarehouse(long id, WarehouseRequestDTO warehouseRequestDTO);
        public Task<ApiResponse> DeleteWarehouse(long id);
    }
}
