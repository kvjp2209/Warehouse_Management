using AutoMapper;
using Web_Api.Data;
using System;
using System.Collections.Generic;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;
using Web_Api.Repositories.Interfaces;
using Web_Api.Services.Interfaces;

namespace Web_Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateOrder(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                return await _orderRepository.CreateOrder(orderRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteOrder(long id)
        {
            try
            {
                return await _orderRepository.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderResponseDTO>> GetAllOrders()
        {
            try
            {
                return _mapper.Map<List<OrderResponseDTO>>(await _orderRepository.GetAllOrders());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderResponseDTO> GetOrderById(long id)
        {
            try
            {
                return _mapper.Map<OrderResponseDTO>(await _orderRepository.GetOrderById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateOrder(long id, OrderRequestDTO orderRequestDTO)
        {
            try
            {
                return await _orderRepository.UpdateOrder(id, orderRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
