using OJTMS_API.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Service.Interfaces
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
