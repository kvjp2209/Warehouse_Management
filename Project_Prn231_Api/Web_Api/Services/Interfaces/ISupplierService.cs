using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface ISupplierService
    {
        public Task<List<SupplierResponseDTO>> GetAllSuppliers();
        public Task<SupplierResponseDTO> GetSupplierById(long id);
        public Task<ApiResponse> CreateSupplier(SupplierRequestDTO supplierRequestDTO);
        public Task<ApiResponse> UpdateSupplier(long id, SupplierRequestDTO supplierRequestDTO);
        public Task<ApiResponse> DeleteSupplier(long id);
    }
}
