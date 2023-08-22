using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;

namespace Web_Api.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        public Task<List<OrderDetail>> GetAllOrderDetails();
        public Task<OrderDetail> GetOrderDetailById(long id);
        public Task<ApiResponse> CreateOrderDetail(OrderDetailRequestDTO orderDetailRequestDTO);
        public Task<ApiResponse> UpdateOrderDetail(long id, OrderDetailRequestDTO orderDetailRequestDTO);
        public Task<ApiResponse> DeleteOrderDetail(long id);
    }
}
