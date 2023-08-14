using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OJTMS_API.Data;
using System;
using System.Collections.Generic;
using Web_Api.Commons;
using Web_Api.Data;
using Web_Api.Data.RequestDTO;
using Web_Api.Models;
using Web_Api.Repositories.Interfaces;

namespace Web_Api.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetails()
        {
            try
            {
                return await _context.OrderDetails.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetail> GetOrderDetailById(long id)
        {
            try
            {
                return await _context.OrderDetails.FirstOrDefaultAsync(x => x.OrderDetailId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateOrderDetail(OrderDetailRequestDTO orderDetailRequestDTO)
        {
            try
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailRequestDTO);
                _context.OrderDetails!.Add(orderDetail);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var orderDetail = GetOrderDetailById(id).Result;
                if (orderDetail == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                orderDetail.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
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
                var orderDetail = GetOrderDetailById(id).Result;
                if (id != orderDetailRequestDTO.OrderDetailId || orderDetail == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                orderDetail = _mapper.Map(orderDetailRequestDTO, orderDetail);
                _context.Update(orderDetail);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
