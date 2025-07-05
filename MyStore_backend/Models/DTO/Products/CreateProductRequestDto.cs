namespace MyStore_backend.Models.Dto.Products
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int? Stock { get; set; }
    }
}
