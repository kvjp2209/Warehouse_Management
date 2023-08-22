using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderResponseDTO>> GetAllOrders();
        public Task<OrderResponseDTO> GetOrderById(long id);
        public Task<ApiResponse> CreateOrder(OrderRequestDTO orderRequestDTO);
        public Task<ApiResponse> UpdateOrder(long id, OrderRequestDTO orderRequestDTO);
        public Task<ApiResponse> DeleteOrder(long id);
    }
}
