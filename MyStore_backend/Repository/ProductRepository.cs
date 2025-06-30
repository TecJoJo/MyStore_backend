using Microsoft.EntityFrameworkCore;
using MyStore_backend.Data;
using MyStore_backend.Models.Dto;

namespace MyStore_backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreProductsDBContext _myStoreProductsDBContext;

        public ProductRepository(
        MyStoreProductsDBContext myStoreProductsDBContext
        )
        {
            _myStoreProductsDBContext = myStoreProductsDBContext;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _myStoreProductsDBContext.Products.ToListAsync();

            var productsResponse = products.Select(product => new ProductDto()
            {
                Category = product.Category,
                Description = product.Description,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            }).ToList();

            return productsResponse;
        }
    }
}
