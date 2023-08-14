using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> GetOrderById(long id);
        public Task<ApiResponse> CreateOrder(OrderRequestDTO orderRequestDTO);
        public Task<ApiResponse> UpdateOrder(long id, OrderRequestDTO orderRequestDTO);
        public Task<ApiResponse> DeleteOrder(long id);
    }
}
