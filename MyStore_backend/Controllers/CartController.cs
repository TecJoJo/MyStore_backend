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
        private readonly ILogger<CartController> _logger;

        public CartController(ICartRepository cartRepository, ILogger<CartController> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]

        public async Task<ActionResult> GetCartItems()
        {
            var userId = GetCurrentUserGuid();
            if (userId == null)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Failed parsing the user's identity"
                };
                return BadRequest(result);
            }

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
            catch (InvalidOperationException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Database operation failed",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "Database operation failed while fetching cart items for user {UserId}", userId);
                return StatusCode(500, result);
            }
            catch (Exception ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "An unexpected error occurred while fetching cart items for user {UserId}", userId);
                return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("cartitem")]
        [Authorize]
        public async Task<ActionResult> AddCartItem(AddCartItemDto addCartItemDto)
        {
            var userId = GetCurrentUserGuid();
            if (userId == null)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Failed parsing the user's identity"
                };
                return BadRequest(result);
            }

            addCartItemDto.UserId = (Guid)userId;
            try
            {
                var cartItemId = await _cartRepository.AddCartItem(addCartItemDto);
                var response = new ApiResponseDto<Guid>()
                {
                    Data = cartItemId,
                    Message = "CartItem added",
                    Success = true
                };
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Database operation failed",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "Database operation failed while adding cart item for user {UserId}", userId);
                return StatusCode(500, result);
            }
            catch (Exception ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "An unexpected error occurred while adding cart item for user {UserId}", userId);
                return StatusCode(500, result);
            }
        }

        [HttpPut]
        [Route("cartitem/{CartItemId}")]
        [Authorize]
        public async Task<ActionResult> ModifyCartItemQuantity([FromRoute] Guid CartItemId, [FromBody] ModifyCartItemQuantityRequestDto modifyCartItemQuantityRequestDto)
        {
            if (modifyCartItemQuantityRequestDto.Quantity <= 0)
            {
                return BadRequest(new ApiResponseDto
                {
                    Success = false,
                    Message = "Quantity must be greater than zero"
                });
            }

            var userId = GetCurrentUserGuid();
            if (userId == null)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Failed parsing the user's identity"
                };
                return BadRequest(result);
            }


            try
            {
                var cartItemDto = await _cartRepository.ModifyCartItemQuantity(CartItemId, modifyCartItemQuantityRequestDto.Quantity, (Guid)userId);
                var response = new ApiResponseDto<CartItemDto>()
                {
                    Data = cartItemDto,
                    Message = "Quantity is updated",
                    Success = true

                };
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "You are not authorized to modify this cart item",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogWarning(ex, "Unauthorized access attempt to modify cart item with ID {CartItemId} by user {UserId}", CartItemId, userId);
                return Unauthorized(result);
            }
            catch (KeyNotFoundException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "CartItem not found",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogWarning(ex, "Cart item with ID {CartItemId} not found", CartItemId);
                return NotFound(result);
            }
            catch (InvalidOperationException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Database operation failed",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "Database operation failed while modifying cart item with ID {CartItemId}", CartItemId);
                return StatusCode(500, result);
            }
            catch (Exception ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "An unexpected error occurred while modifying cart item with ID {CartItemId}", CartItemId);
                return StatusCode(500, result);
            }

        }

        [HttpDelete]
        [Route("cartitem/{CartItemId}")]
        [Authorize]
        public async Task<ActionResult> DeleteCartItem(Guid CartItemId)
        {
            var userId = GetCurrentUserGuid();
            if (userId == null)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Failed parsing the user's identity"
                };
                return BadRequest(result);
            }
            try
            {
                await _cartRepository.RemoveCartItem(CartItemId, (Guid)userId);
                var response = new ApiResponseDto<Guid>()
                {
                    Data = CartItemId,
                    Message = "CartItem deleted",
                    Success = true
                };
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "You are not authorized to delete this cart item",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogWarning(ex, "Unauthorized access attempt to delete cart item with ID {CartItemId} by user {UserId}", CartItemId, userId);
                return Unauthorized(result);
            }
            catch (KeyNotFoundException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "CartItem not found",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogWarning(ex, "Cart item with ID {CartItemId} not found", CartItemId);
                return NotFound(result);
            }
            catch (InvalidOperationException ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "Database operation failed",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "Database operation failed while deleting cart item with ID {CartItemId}", CartItemId);
                return StatusCode(500, result);
            }
            catch (Exception ex)
            {
                var result = new ApiResponseDto()
                {
                    Success = false,
                    Message = "An unexpected error occurred",
                    Errors = new List<string>() { ex.Message }
                };
                _logger.LogError(ex, "An unexpected error occurred while deleting cart item with ID {CartItemId}", CartItemId);
                return StatusCode(500, result);
            }
        }


        private Guid? GetCurrentUserGuid()
        {
            var userIdClaim = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var parsedResult = Guid.TryParse(userIdClaim, out Guid userId);
            return parsedResult ? userId : null;
        }
    }
}
