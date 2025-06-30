using MyStore_backend.Models.Dto;

namespace MyStore_backend.Repository
{
    public interface IProductRepository
    {
        public Task<List<ProductResponseDto>> GetAllProductsAsync();

        public Task<Guid> CreateProduct(CreateProductRequestDto createProductRequestDto);

        public Task<bool> DeleteProduct(Guid productId);
    }
}
