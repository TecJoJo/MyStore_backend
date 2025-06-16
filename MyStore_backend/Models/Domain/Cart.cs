using System.ComponentModel.DataAnnotations;

namespace MyStore_backend.Models.Domain
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        //navigation 
        public Product Product { get; set; }
    }
}
