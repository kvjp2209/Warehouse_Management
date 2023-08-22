using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Services.Interfaces
{
    public interface IOrderDetailService
    {
        public Task<List<OrderDetailResponseDTO>> GetAllOrderDetails();
        public Task<OrderDetailResponseDTO> GetOrderDetailById(long id);
        public Task<ApiResponse> CreateOrderDetail(OrderDetailRequestDTO orderDetailRequestDTO);
        public Task<ApiResponse> UpdateOrderDetail(long id, OrderDetailRequestDTO orderDetailRequestDTO);
        public Task<ApiResponse> DeleteOrderDetail(long id);
    }
}
