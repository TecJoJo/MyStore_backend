﻿using MyStore_backend.Models.Dto.Cart;

namespace MyStore_backend.Repository.Cart
{
    public interface ICartRepository
    {
        public Task<Guid> AddCartItem(AddCartItemDto addCartItemDto);
        public Task<List<CartItemDto>> GetCartItems(Guid userId);
        public Task<CartItemDto> ModifyCartItemQuantity(Guid cartItemId, int quantity, Guid userId);
        public Task RemoveCartItem(Guid cartItemId, Guid userId);
    }
}
