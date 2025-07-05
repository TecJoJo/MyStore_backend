using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_backend.Data;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Products;

namespace MyStore_backend.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreProductsDBContext _myStoreProductsDBContext;
        private readonly IMapper _mapper;

        public ProductRepository(
        MyStoreProductsDBContext myStoreProductsDBContext,
        IMapper mapper
        )
        {
            _myStoreProductsDBContext = myStoreProductsDBContext;
            _mapper = mapper;
        }



        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _myStoreProductsDBContext.Products.ToListAsync();

            var productsResponse = products.Select(product => _mapper.Map<Product, ProductResponseDto>(product)).ToList();

            return productsResponse;
        }

        public async Task<Guid> CreateProduct(CreateProductRequestDto createProductRequestDto)
        {


            var newProduct = _mapper.Map<CreateProductRequestDto, Product>(createProductRequestDto);

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


                _mapper.Map(editProductRequestDto, product);

                await _myStoreProductsDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
