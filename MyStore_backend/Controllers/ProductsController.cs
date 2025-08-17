using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Data;
using MyStore_backend.Models.Dto;
using MyStore_backend.Models.Dto.Products;
using MyStore_backend.Models.DTO.Products;
using MyStore_backend.Repository.Products;

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
                        Message = "Product deleted successfully",
                        Success = true
                    };
                    return Ok(successResponse);
                }
                else
                {
                    var notFoundResponse = new ApiResponseDto<bool>
                    {
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
                    Success = false,
                    Errors = new List<string> { ex.Message },

                };
                return BadRequest(errorResponse);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProducts([FromBody] DeleteProductsDto deleteProductsDto)
        {
            try
            {
                var deleteProductResponseDtos = await _productRepository.DeleteProducts(deleteProductsDto);

                // Check if any deletions failed
                var failedDeletions = deleteProductResponseDtos.Where(r => r.IsDeleted == false).ToList();
                var successfulDeletions = deleteProductResponseDtos.Where(r => r.IsDeleted == true).ToList();

                if (failedDeletions.Any())
                {
                    // Partial success - some failed, some succeeded
                    var partialSuccessResponse = new ApiResponseDto<List<DeleteProductResponseDto>>()
                    {
                        Data = deleteProductResponseDtos,
                        Success = false, // Overall operation considered failed due to partial failures
                        Message = $"Partial success: {successfulDeletions.Count} product(s) deleted successfully, {failedDeletions.Count} product(s) failed. See data for details.",
                        Errors = failedDeletions.Select(f => f.ErrorMessage ?? "Unknown error").ToList()
                    };

                    // Return 207 Multi-Status for partial success (or 200 OK with Success=false)
                    return StatusCode(207, partialSuccessResponse);
                }
                else
                {
                    // Complete success - all deletions succeeded
                    var successResponse = new ApiResponseDto<List<DeleteProductResponseDto>>()
                    {
                        Data = deleteProductResponseDtos,
                        Success = true,
                        Message = $"All {successfulDeletions.Count} product(s) deleted successfully"
                    };

                    return Ok(successResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseDto<List<DeleteProductResponseDto>>
                {
                    Success = false,
                    Message = "Unexpected error occurred during bulk delete operation",
                    Errors = new List<string> { ex.Message }
                };
                return StatusCode(500, errorResponse);
            }
        }
        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] Guid productId, [FromBody] EditProductRequestDto editProductRequestDto)
        {
            try
            {

                var result = await _productRepository.UpdateProduct(productId, editProductRequestDto);
                if (result)
                {
                    var successResponse = new ApiResponseDto<bool>
                    {
                        Message = "Product updated successfully",
                        Success = true
                    };
                    return Ok(successResponse);
                }
                else
                {
                    var notFoundResponse = new ApiResponseDto<bool>
                    {
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
                    Success = false,
                    Errors = new List<string> { ex.Message },
                };
                return BadRequest(errorResponse);
            }



        }
    }
}
