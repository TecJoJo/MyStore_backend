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
            var parsingResult = Guid.TryParse(HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out Guid userId);
            try
            {
                var cartItems = await _cartRepository.GetCartItems(userId);
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


            //if user is not logged in return empty list 
        }

        [HttpPost]
        [Route("cartitem")]
        [Authorize]
        public async Task<ActionResult> AddCartItem(AddCartItemDto addCartItemDto)
        {
            var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                var userGuid = Guid.Parse(userId);
                addCartItemDto.UserId = userGuid;
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
                return Forbid();
            }


        }
    }
}
