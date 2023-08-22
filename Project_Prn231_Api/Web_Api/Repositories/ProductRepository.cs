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
    public class ProductRepository : IProductRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public ProductRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Products
                    .Include(x => x.Warehouse).Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductById(long id)
        {
            try
            {
                return await _context.Products
                    .Include(x => x.Warehouse).FirstOrDefaultAsync(x => x.ProductId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequestDTO);
                _context.Products!.Add(product);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteProduct(long id)
        {
            try
            {
                var product = GetProductById(id).Result;
                if (product == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateProduct(long id, ProductRequestDTO productRequestDTO)
        {
            try
            {
                var product = GetProductById(id).Result;
                if (id != productRequestDTO.ProductId || product == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                product = _mapper.Map(productRequestDTO, product);
                _context.Update(product);
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
