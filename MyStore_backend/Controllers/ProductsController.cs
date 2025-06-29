using Microsoft.AspNetCore.Mvc;
using MyStore_backend.Data;
using MyStore_backend.Models.Dto;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly MyStoreProductsDBContext _myStoreProductsDBContext;
        protected readonly MyStoreAuthDBContext _myStoreAuthDB;

        public ProductsController(MyStoreProductsDBContext myStoreProductsDBContext, MyStoreAuthDBContext myStoreAuthDBContext)
        {
            _myStoreProductsDBContext = myStoreProductsDBContext;
            _myStoreAuthDB = myStoreAuthDBContext;
        }

        [HttpGet]
        [Route("allProducts")]
        public IActionResult GetProducts()
        {
            var products = _myStoreProductsDBContext.Products.ToList();

            var productsDto = products.Select(product => new ProductDto()
            {
                Category = product.Category,
                Description = product.Description,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            }).ToList();

            var apiResponse = new ApiResponseDto<GetProductsResponseDto>()
            {
                Data = new GetProductsResponseDto { Products = productsDto },
                Message = "Products retrieved successfully",
                Success = true
            };

            return Ok(apiResponse);
        }
    }
}
