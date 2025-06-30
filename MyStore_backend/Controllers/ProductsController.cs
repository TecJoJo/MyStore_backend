using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Data;
using MyStore_backend.Models.Dto;
using MyStore_backend.Repository;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly MyStoreProductsDBContext _myStoreProductsDBContext;
        protected readonly MyStoreAuthDBContext _myStoreAuthDB;
        protected readonly IProductRepository _productRepository;

        public ProductsController(
            MyStoreProductsDBContext myStoreProductsDBContext,
            MyStoreAuthDBContext myStoreAuthDBContext,
            IProductRepository productRepository
        )
        {
            _myStoreProductsDBContext = myStoreProductsDBContext;
            _myStoreAuthDB = myStoreAuthDBContext;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();

            var apiResponse = new ApiResponseDto<List<ProductResponseDto>>()
            {
                Data = products,
                Message = "Products retrieved successfully",
                Success = true
            };

            return Ok(apiResponse);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequestDto createProductRequestDto)
        {
            try
            {
                var productId = await _productRepository.CreateProduct(createProductRequestDto);
                var successResponse = new ApiResponseDto<Guid>
                {
                    Data = productId,
                    Message = "Product created successfully",
                    Success = true
                };

                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<CreateProductRequestDto>
                {
                    Data = createProductRequestDto,
                    Success = false,
                    Errors = new List<string> { ex.Message }

                };

                return BadRequest(errorResponse);
            }




        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            try
            {
                var isDeleted = await _productRepository.DeleteProduct(productId);
                if (isDeleted)
                {
                    var successResponse = new ApiResponseDto<bool>
                    {
                        Data = true,
                        Message = "Product deleted successfully",
                        Success = true
                    };
                    return Ok(successResponse);
                }
                else
                {
                    var notFoundResponse = new ApiResponseDto<bool>
                    {
                        Data = false,
                        Message = "Product not found",
                        Success = false
                    };
                    return NotFound(notFoundResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<bool>
                {
                    Data = false,
                    Success = false,
                    Errors = new List<string> { ex.Message },

                };
                return BadRequest(errorResponse);
            }
        }


    }
}
