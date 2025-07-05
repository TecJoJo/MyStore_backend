using MyStore_backend.Models.Dto.Products;

namespace MyStore_backend.Repository.Products
{
    public interface IProductRepository
    {
        public Task<List<ProductResponseDto>> GetAllProductsAsync();

        public Task<Guid> CreateProduct(CreateProductRequestDto createProductRequestDto);

        public Task<bool> DeleteProduct(Guid productId);

        public Task<bool> UpdateProduct(Guid productId, EditProductRequestDto editProductRequestDto);
    }
}
