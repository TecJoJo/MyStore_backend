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

        public async Task<CartItemDto> ModifyCartItemQuantity(Guid userId, Guid productId, int quantity)
        {
            var cartItemQueryable = _myStoreProductsDBContext.CartItems.Where(c => c.UserId == userId && c.ProductId == productId);

            var cartItem = await cartItemQueryable.FirstOrDefaultAsync();

            if (cartItem == null) throw new Exception("The carItem is not found");

            cartItem.Quantity = quantity;
            await _myStoreProductsDBContext.SaveChangesAsync();



            //prepare the response
            var cartItemDto = await cartItemQueryable.Join(
                _myStoreProductsDBContext.Products,
                c => c.ProductId,
                p => p.Id,
                (c, p) => new CartItemDto()
                {
                    Id = c.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = c.Quantity
                }).FirstOrDefaultAsync()!;

            return cartItemDto!;






        }
    }
}
