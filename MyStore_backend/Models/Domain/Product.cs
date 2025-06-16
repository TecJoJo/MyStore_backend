using System.ComponentModel.DataAnnotations;

namespace MyStore_backend.Models.Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }

        //navigaion
        public ICollection<Cart> Carts { get; set; }
    }
}
