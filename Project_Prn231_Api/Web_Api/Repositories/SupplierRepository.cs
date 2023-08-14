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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly Project_Prn231Context _context;
        private readonly IMapper _mapper;

        public SupplierRepository(Project_Prn231Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                return await _context.Suppliers.Where(x => x.IsDeleted.Equals(false)).OrderByDescending(x => x.CreatedOn).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Supplier> GetSupplierById(long id)
        {
            try
            {
                return await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id && x.IsDeleted.Equals(false));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateSupplier(SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierRequestDTO);
                _context.Suppliers!.Add(supplier);
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteSupplier(long id)
        {
            try
            {
                var supplier = GetSupplierById(id).Result;
                if (supplier == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                supplier.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new ApiResponse { IsSuccess = true, Message = MessageConstants.SUCCESS };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateSupplier(long id, SupplierRequestDTO supplierRequestDTO)
        {
            try
            {
                var supplier = GetSupplierById(id).Result;
                if (id != supplierRequestDTO.SupplierId || supplier == null)
                {
                    return new ApiResponse { IsSuccess = false, Message = MessageConstants.ITEM_NOT_EXISTED };
                }
                supplier = _mapper.Map(supplierRequestDTO, supplier);
                _context.Update(supplier);
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
