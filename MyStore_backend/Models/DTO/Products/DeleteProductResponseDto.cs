namespace MyStore_backend.Models.DTO.Products
{
    public class DeleteProductResponseDto
    {
        public Guid ProductId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }
}