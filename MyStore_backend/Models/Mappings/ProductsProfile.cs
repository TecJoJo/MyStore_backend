using AutoMapper;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Products;

namespace MyStore_backend.Models.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductResponseDto>();
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<EditProductRequestDto, Product>();
        }
    }
}
