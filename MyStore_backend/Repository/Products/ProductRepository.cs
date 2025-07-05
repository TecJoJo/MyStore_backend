using Microsoft.EntityFrameworkCore;
using MyStore_backend.Data;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Products;

namespace MyStore_backend.Repository.Products
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



        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _myStoreProductsDBContext.Products.ToListAsync();

            var productsResponse = products.Select(product => new ProductResponseDto()
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

        public async Task<Guid> CreateProduct(CreateProductRequestDto createProductRequestDto)
        {
            var newProduct = new Product()
            {
                Category = createProductRequestDto.Category,
                Description = createProductRequestDto.Description,
                ImageUrl = createProductRequestDto.ImageUrl,
                Name = createProductRequestDto.Name,
                Price = createProductRequestDto.Price,
                Stock = createProductRequestDto.Stock ?? 0
            };

            await _myStoreProductsDBContext.AddAsync(newProduct);
            await _myStoreProductsDBContext.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var productToRemove = await _myStoreProductsDBContext.Products.FirstOrDefaultAsync((p) => p.Id == productId);
            if (productToRemove != null)
            {
                _myStoreProductsDBContext.Remove(productToRemove);
                await _myStoreProductsDBContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateProduct(Guid productId, EditProductRequestDto editProductRequestDto)
        {
            var product = await _myStoreProductsDBContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product != null)
            {


                product.Price = editProductRequestDto.Price;
                product.Category = editProductRequestDto.Category;
                product.Name = editProductRequestDto.Name;
                product.ImageUrl = editProductRequestDto.ImageUrl;
                product.Description = editProductRequestDto.Description;

                await _myStoreProductsDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
