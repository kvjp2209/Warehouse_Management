using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Service.Interfaces
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
