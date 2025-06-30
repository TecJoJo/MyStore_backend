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
        [Route("allProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();

            var apiResponse = new ApiResponseDto<List<ProductDto>>()
            {
                Data = products,
                Message = "Products retrieved successfully",
                Success = true
            };

            return Ok(apiResponse);
        }
    }
}
