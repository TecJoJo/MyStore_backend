using MyStore_backend.Models.Dto;

namespace MyStore_backend.Repository
{
    public interface IProductRepository
    {
        public Task<List<ProductDto>> GetAllProductsAsync();
    }
}
