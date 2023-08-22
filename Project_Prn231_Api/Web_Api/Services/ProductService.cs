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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                return await _productRepository.CreateProduct(productRequestDTO);
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
                return await _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductResponseDTO>> GetAllProducts()
        {
            try
            {
                return _mapper.Map<List<ProductResponseDTO>>(await _productRepository.GetAllProducts());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductResponseDTO> GetProductById(long id)
        {
            try
            {
                return _mapper.Map<ProductResponseDTO>(await _productRepository.GetProductById(id));
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
                return await _productRepository.UpdateProduct(id, productRequestDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
