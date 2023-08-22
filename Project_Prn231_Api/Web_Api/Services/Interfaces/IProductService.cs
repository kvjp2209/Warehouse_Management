using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductResponseDTO>> GetAllProducts();
        public Task<ProductResponseDTO> GetProductById(long id);
        public Task<ApiResponse> CreateProduct(ProductRequestDTO productRequestDTO);
        public Task<ApiResponse> UpdateProduct(long id, ProductRequestDTO productRequestDTO);
        public Task<ApiResponse> DeleteProduct(long id);
    }
}
