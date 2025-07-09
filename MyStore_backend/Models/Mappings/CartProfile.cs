using AutoMapper;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Cart;

namespace MyStore_backend.Models.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<AddCartItemDto, CartItem>();
        }
    }
}
