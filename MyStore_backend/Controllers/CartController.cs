using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Models.Dto;
using MyStore_backend.Models.Dto.Cart;
using MyStore_backend.Repository.Cart;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("cart")]
        [Authorize]
        public async Task<ActionResult> GetCartItems()
        {
            var userId = GetCurrentUserGuid();
            if (userId != null)
            {

                try
                {
                    var cartItems = await _cartRepository.GetCartItems((Guid)userId);
                    var result = new ApiResponseDto<List<CartItemDto>>()
                    {
                        Data = cartItems,
                        Message = "Cart items for user is found",
                        Success = true
                    };
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    var result = new ApiResponseDto<List<CartItemDto>>()
                    {
                        Success = false,
                        Message = "Failed to get cart items",
                        Errors = new List<string>() { ex.Message }
                    };
                    return BadRequest(result);
                }
            }
            else
            {

                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Something is wrong, failed parsing the user's identity"
                };
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("cartitem")]
        [Authorize]
        public async Task<ActionResult> AddCartItem(AddCartItemDto addCartItemDto)
        {
            var userId = GetCurrentUserGuid();
            if (userId != null)
            {

                addCartItemDto.UserId = (Guid)userId;
                try
                {
                    var carItemId = await _cartRepository.AddCartItem(addCartItemDto);
                    var response = new ApiResponseDto<Guid>()
                    {
                        Data = carItemId,
                        Message = "CartItem added",
                        Success = true
                    };
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    var response = new ApiResponseDto<AddCartItemDto>()
                    {
                        Success = false,
                        Data = addCartItemDto,
                        Message = "Failed to create cart item!",
                        Errors = new List<string>() { ex.Message }


                    };
                    return BadRequest(response);
                }
            }
            else
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Something is wrong, failed parsing the user's identity"
                };
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("cartitem/{CartItemId}")]
        [Authorize]
        public async Task<ActionResult> ModifyCarItemQuantity(Guid CartItemId, int quantity)
        {
            try
            {
                var cartItemDto = await _cartRepository.ModifyCartItemQuantity(CartItemId, quantity);
                var response = new ApiResponseDto<CartItemDto>()
                {
                    Data = cartItemDto,
                    Message = "Quantity is updated",
                    Success = true

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Failed to create cart item!",
                    Errors = new List<string>() { ex.Message }


                };
                return BadRequest(response);
            }

        }

        private Guid? GetCurrentUserGuid()
        {
            var userIdClaim = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var parsingResult = Guid.TryParse(userIdClaim, out Guid userId);
            return parsingResult ? userId : null;
        }
    }
}
