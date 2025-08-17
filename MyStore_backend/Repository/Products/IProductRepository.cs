using MyStore_backend.Models.Dto.Products;
using MyStore_backend.Models.DTO.Products;

namespace MyStore_backend.Repository.Products
{
    public interface IProductRepository
    {
        public Task<List<ProductResponseDto>> GetAllProductsAsync();

        public Task<Guid> CreateProduct(CreateProductRequestDto createProductRequestDto);

        public Task<bool> DeleteProduct(Guid productId);

        public Task<List<DeleteProductResponseDto>> DeleteProducts(DeleteProductsDto deleteProductsDto);

        public Task<bool> UpdateProduct(Guid productId, EditProductRequestDto editProductRequestDto);
    }
}
