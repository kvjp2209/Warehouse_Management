using AutoMapper;
using OJTMS_API.Data;
using System;
using System.Collections.Generic;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Repositories.Interfaces;
using Web_Api.Service.Interfaces;

namespace Web_Api.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateOrderDetail(OrderDetailRequestDTO orderDetailRequestDTO)
        {
            try
            {
                return await _orderDetailRepository.CreateOrderDetail(orderDetailRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteOrderDetail(long id)
        {
            try
            {
                return await _orderDetailRepository.DeleteOrderDetail(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderDetailResponseDTO>> GetAllOrderDetails()
        {
            try
            {
                return _mapper.Map<List<OrderDetailResponseDTO>>(await _orderDetailRepository.GetAllOrderDetails());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetailResponseDTO> GetOrderDetailById(long id)
        {
            try
            {
                return _mapper.Map<OrderDetailResponseDTO>(await _orderDetailRepository.GetOrderDetailById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateOrderDetail(long id, OrderDetailRequestDTO orderDetailRequestDTO)
        {
            try
            {
                return await _orderDetailRepository.UpdateOrderDetail(id, orderDetailRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
