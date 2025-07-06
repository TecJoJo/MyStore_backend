using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_backend.Data;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Cart;

namespace MyStore_backend.Repository.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly MyStoreProductsDBContext _myStoreProductsDBContext;
        public CartRepository(
            MyStoreProductsDBContext myStoreProductsDBContext,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _myStoreProductsDBContext = myStoreProductsDBContext;
        }
        public async Task<Guid> AddCartItem(AddCartItemDto addCartItemDto)
        {
            var newCartItem = _mapper.Map<AddCartItemDto, CartItem>(addCartItemDto);
            await _myStoreProductsDBContext.AddAsync(newCartItem);
            await _myStoreProductsDBContext.SaveChangesAsync();
            return newCartItem.Id;
        }

        public async Task<List<CartItemDto>> GetCartItems(Guid userId)
        {
            var cartItems =
                await _myStoreProductsDBContext.CartItems
                .Join(
                _myStoreProductsDBContext.Products,
                c => c.ProductId,
                p => p.Id,
                (cartItem, product) => new { cartItem, product })
                .Where(newObject => newObject.cartItem.UserId == userId)
                .Select(newObject => new CartItemDto()
                {
                    Id = newObject.cartItem.Id,
                    ImageUrl = newObject.product.ImageUrl,
                    Name = newObject.product.Name,
                    Price = newObject.product.Price,
                    Quantity = newObject.cartItem.Quantity,
                }).ToListAsync();

            if (cartItems == null) return new List<CartItemDto>();
            return cartItems;
        }
    }
}
