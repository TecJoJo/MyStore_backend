namespace MyStore_backend.Models.Dto.Cart
{
    public class AddCartItemDto
    {
        public Guid? UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
