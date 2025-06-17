using Microsoft.EntityFrameworkCore;
using MyStore_backend.Models.Domain;

namespace MyStore_backend.Data
{
    public class MyStoreProductsDBContext : DbContext
    {
        public MyStoreProductsDBContext(DbContextOptions<MyStoreProductsDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
                .HasOne(cart => cart.Product)
                .WithMany(product => product.CartItems)
                .HasForeignKey(cart => cart.ProductId);


            var products = new List<Product>()
            {
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Classic White T-Shirt",
                    Description = "A stylish white T-Shirt",
                    Price = 29.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1512436991641-6745cdb1723f?auto=format&fit=crop&w=400&q=80",
                    Category = "T-Shirt",
                    Stock = 99
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Denim Jeans",
                    Description = "Classic blue denim jeans",
                    Price = 59.99m,
                    ImageUrl = "https://vilapuuvilla.fi/cdn/shop/products/0520bad2-dc50-40ae-9f90-afce00862eff_14094341_4429742_001_preview.jpg?v=1701160840",
                    Category = "Jeans",
                    Stock = 50
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Running Sneakers",
                    Description = "Comfortable running sneakers",
                    Price = 89.99m,
                    ImageUrl = "https://pyxis.nymag.com/v1/imgs/a6d/fc0/4da4be21d1741718404660586a5b6a6f3e.jpg",
                    Category = "Shoes",
                    Stock = 30
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Leather Wallet",
                    Description = "Premium brown leather wallet",
                    Price = 39.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81WIcyHQ7oL._AC_UY1100_.jpg",
                    Category = "Accessories",
                    Stock = 40
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Baseball Cap",
                    Description = "Red adjustable baseball cap",
                    Price = 19.99m,
                    ImageUrl = "https://store.moma.org/cdn/shop/files/3a2b0b12-bde3-4a63-bba2-b561dbd7de29_5fa67989-c4a0-4bea-a74b-fb25ed894895.jpg?v=1710971142",
                    Category = "Hats",
                    Stock = 60
                }
            };
            modelBuilder.Entity<Product>().HasData(products);

            // Seed carts: each user has 5 items (one for each product)
            var carts = new List<CartItem>()
            {
                // Cart for dummyuser@example.com (UserId: 11111111-1111-1111-1111-111111111111)
                new CartItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Quantity = 2
                },
                new CartItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Quantity = 1
                },
                new CartItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Quantity = 1
                },
                new CartItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Quantity = 3
                },
                new CartItem
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Quantity = 2
                },

                // Cart for anotheruser@example.com (UserId: 22222222-2222-2222-2222-222222222222)
                new CartItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Quantity = 1
                },
                new CartItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Quantity = 2
                },
                new CartItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Quantity = 2
                },
                new CartItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Quantity = 1
                },
                new CartItem
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"),
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Quantity = 3
                }
            };
            modelBuilder.Entity<CartItem>().HasData(carts);
        }


    }
}
