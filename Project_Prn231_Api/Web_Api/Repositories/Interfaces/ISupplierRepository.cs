using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        public Task<List<Supplier>> GetAllSuppliers();
        public Task<Supplier> GetSupplierById(long id);
        public Task<ApiResponse> CreateSupplier(SupplierRequestDTO supplierRequestDTO);
        public Task<ApiResponse> UpdateSupplier(long id, SupplierRequestDTO supplierRequestDTO);
        public Task<ApiResponse> DeleteSupplier(long id);
    }
}
