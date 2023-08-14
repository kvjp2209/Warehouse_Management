using AutoMapper;
using Web_Api.Models;
using Web_Api.Data.RequestDTO;
using Web_Api.Data.ResponseDTO;

namespace Web_Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            // Map Models to ResponseDTO
            CreateMap<Batch, BatchResponseDTO>()
                .ForMember(dest => dest.ProductResponseDTO, opt => opt.MapFrom(ps => ps.Product))
                .ForMember(dest => dest.SupplierResponseDTO, opt => opt.MapFrom(ps => ps.Supplier))
                .ForMember(dest => dest.WarehouseResponseDTO, opt => opt.MapFrom(ps => ps.Warehouse));

            CreateMap<Employee, EmployeeResponseDTO>();

            CreateMap<InventoryCheck, InventoryCheckResponseDTO>()
                .ForMember(dest => dest.WarehouseResponseDTO, opt => opt.MapFrom(ps => ps.Warehouse));

            CreateMap<Order, OrderResponseDTO>()
                .ForMember(dest => dest.EmployeeResponseDTO, opt => opt.MapFrom(ps => ps.Employee));

            CreateMap<OrderDetail, OrderDetailResponseDTO>()
                .ForMember(dest => dest.ProductResponseDTO, opt => opt.MapFrom(ps => ps.Product))
                .ForPath(dest => dest.ProductResponseDTO.WarehouseResponseDTO, opt => opt.MapFrom(src => src.Product.Warehouse))
                .ForMember(dest => dest.OrderResponseDTO, opt => opt.MapFrom(ps => ps.Order))
                .ForPath(dest => dest.OrderResponseDTO.EmployeeResponseDTO, opt => opt.MapFrom(src => src.Order.Employee));

            CreateMap<Product, ProductResponseDTO>()
                .ForMember(dest => dest.WarehouseResponseDTO, opt => opt.MapFrom(ps => ps.Warehouse));

            CreateMap<Supplier, SupplierResponseDTO>();

            CreateMap<Warehouse, WarehouseResponseDTO>();

            // Map RequestDTO to Models
            CreateMap<BatchRequestDTO, Batch>();
            CreateMap<EmployeeRequestDTO, Employee>();
            CreateMap<InventoryCheckRequestDTO, InventoryCheck>();
            CreateMap<OrderRequestDTO, Order>();
            CreateMap<OrderDetailRequestDTO, OrderDetail>();
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<SupplierRequestDTO, Supplier>();
            CreateMap<WarehouseRequestDTO, Warehouse>();
        }
    }
}
