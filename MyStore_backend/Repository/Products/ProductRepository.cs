using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore_backend.Data;
using MyStore_backend.Models.Domain;
using MyStore_backend.Models.Dto.Products;
using MyStore_backend.Models.DTO.Products;

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

        public async Task<List<DeleteProductResponseDto>> DeleteProducts(DeleteProductsDto deleteProductsDto)
        {

            List<DeleteProductResponseDto> deleteProductResponseDtos = new List<DeleteProductResponseDto>();

            var productsToDelete = (await _myStoreProductsDBContext.Products.Where(p => deleteProductsDto.ProductIds.Contains(p.Id)).ToListAsync()).ToHashSet();

            var productIdsToDelete = productsToDelete.Select(p => p.Id).ToHashSet();



            foreach (var productIdFromDto in deleteProductsDto.ProductIds)
            {
                var response = new DeleteProductResponseDto()
                {
                    ProductId = productIdFromDto,
                    IsDeleted = false
                };

                if (!productIdsToDelete.Contains(productIdFromDto))
                {

                    response.ErrorMessage = $"Product with ProductId {productIdFromDto} is not found";
                }


                deleteProductResponseDtos.Add(response);

            }



            foreach (var productToDelete in productsToDelete)
            {
                try
                {
                    using var transaction = await _myStoreProductsDBContext.Database.BeginTransactionAsync();

                    _myStoreProductsDBContext.Remove(productToDelete);
                    await _myStoreProductsDBContext.SaveChangesAsync();
                    await _myStoreProductsDBContext.Database.CommitTransactionAsync();

                    foreach (var deleteProductResonseDto in deleteProductResponseDtos)
                    {
                        if (deleteProductResonseDto.ProductId == productToDelete.Id)
                        {
                            deleteProductResonseDto.IsDeleted = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    foreach (var deleteProductResonseDto in deleteProductResponseDtos)
                    {
                        if (deleteProductResonseDto.ProductId == productToDelete.Id)
                        {
                            deleteProductResonseDto.IsDeleted = false;
                            deleteProductResonseDto.ErrorMessage = ex.Message;
                        }
                    }
                }
            }






            return deleteProductResponseDtos;
        }
    }
}
