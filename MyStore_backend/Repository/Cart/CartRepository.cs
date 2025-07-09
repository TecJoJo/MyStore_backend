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
                .Include(c => c.Product)
                .Where(cartItem => cartItem.UserId == userId)
                .Select(cartItem => new CartItemDto()
                {
                    Id = cartItem.Id,
                    ImageUrl = cartItem.Product.ImageUrl,
                    Name = cartItem.Product.Name,
                    Price = cartItem.Product.Price,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                })
                .ToListAsync();

            if (cartItems == null) return new List<CartItemDto>();
            return cartItems;
        }

        public async Task<CartItemDto> ModifyCartItemQuantity(Guid cartItemId, int quantity, Guid userId)
        {

            var cartItem = await _myStoreProductsDBContext.CartItems.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == cartItemId);

            if (cartItem == null) throw new KeyNotFoundException($"Cart item with ID '{cartItemId}' was not found");
            if (cartItem.UserId != userId)
            {
                throw new UnauthorizedAccessException($"User with ID '{userId}' is not authorized to modify this cart item");
            }
            cartItem.Quantity = quantity;

            await _myStoreProductsDBContext.SaveChangesAsync();
            var cartItemDto = new CartItemDto()
            {
                Id = cartItem.Id,
                Quantity = cartItem.Quantity,
                ImageUrl = cartItem.Product.ImageUrl,
                Name = cartItem.Product.Name,
                Price = cartItem.Product.Price,
                ProductId = cartItem.ProductId
            };

            return cartItemDto;
        }
    }
}
