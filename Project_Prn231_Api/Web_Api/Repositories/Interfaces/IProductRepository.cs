
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(long id);
        public Task<ApiResponse> CreateProduct(ProductRequestDTO productRequestDTO);
        public Task<ApiResponse> UpdateProduct(long id, ProductRequestDTO productRequestDTO);
        public Task<ApiResponse> DeleteProduct(long id);
    }
}
