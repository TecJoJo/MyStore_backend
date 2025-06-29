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
                    Name = "Premium Classic White T-Shirt",
                    Description = "Experience timeless style and comfort with our Premium Classic White T-Shirt. Crafted from high-quality, breathable cotton, this versatile piece is perfect for any occasion, whether you're dressing up or keeping it casual. Its tailored fit and soft fabric ensure all-day comfort, making it a staple in any modern wardrobe.",
                    Price = 29.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1512436991641-6745cdb1723f?auto=format&fit=crop&w=400&q=80",
                    Category = "T-Shirt",
                    Stock = 99
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Signature Blue Denim Jeans",
                    Description = "Our Signature Blue Denim Jeans offer a classic look with a modern twist. Made from durable, premium denim, these jeans provide a comfortable fit and exceptional longevity. The timeless blue wash and expert tailoring make them suitable for both casual outings and more formal settings, ensuring you always look your best.",
                    Price = 59.99m,
                    ImageUrl = "https://vilapuuvilla.fi/cdn/shop/products/0520bad2-dc50-40ae-9f90-afce00862eff_14094341_4429742_001_preview.jpg?v=1701160840",
                    Category = "Jeans",
                    Stock = 50
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Elite Performance Running Sneakers",
                    Description = "Achieve your fitness goals with our Elite Performance Running Sneakers. Engineered for maximum comfort and support, these sneakers feature advanced cushioning technology and a lightweight, breathable design. Perfect for both daily runs and casual wear, they deliver superior traction and durability for any activity.",
                    Price = 89.99m,
                    ImageUrl = "https://pyxis.nymag.com/v1/imgs/a6d/fc0/4da4be21d1741718404660586a5b6a6f3e.jpg",
                    Category = "Shoes",
                    Stock = 30
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Luxury Brown Leather Wallet",
                    Description = "Keep your essentials organized in style with our Luxury Brown Leather Wallet. Handcrafted from premium genuine leather, this wallet features multiple card slots, a spacious bill compartment, and a sleek, elegant design. Its rich brown color and fine stitching make it a sophisticated accessory for any professional.",
                    Price = 39.99m,
                    ImageUrl = "https://m.media-amazon.com/images/I/81WIcyHQ7oL._AC_UY1100_.jpg",
                    Category = "Accessories",
                    Stock = 40
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Adjustable Red Baseball Cap",
                    Description = "Add a pop of color to your outfit with our Adjustable Red Baseball Cap. Designed for comfort and style, this cap features a customizable fit, breathable fabric, and a classic curved brim. Ideal for outdoor activities or casual wear, it offers both sun protection and a fashionable look.",
                    Price = 19.99m,
                    ImageUrl = "https://store.moma.org/cdn/shop/files/3a2b0b12-bde3-4a63-bba2-b561dbd7de29_5fa67989-c4a0-4bea-a74b-fb25ed894895.jpg?v=1710971142",
                    Category = "Hats",
                    Stock = 60
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Name = "Artisan Cat Graphic White T-Shirt",
                    Description = "Showcase your playful side with our Artisan Cat Graphic White T-Shirt. Made from ultra-soft cotton, this shirt features a unique, artist-designed cat graphic that adds personality to your wardrobe. Its comfortable fit and eye-catching design make it perfect for both casual outings and relaxed weekends.",
                    Price = 29.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1576566588028-4147f3842f27?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8VCUyMHNoaXJ0fGVufDB8fDB8fHww",
                    Category = "T-Shirt",
                    Stock = 99
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Modern Art Text Black T-Shirt",
                    Description = "Express your creativity with our Modern Art Text Black T-Shirt. This premium tee features a bold, artistic text design on high-quality black fabric. Its contemporary style and comfortable fit make it a standout piece for anyone looking to make a statement while enjoying all-day comfort.",
                    Price = 15.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1583744946564-b52ac1c389c8?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fFQlMjBzaGlydHxlbnwwfHwwfHx8MA%3D%3D",
                    Category = "T-Shirt",
                    Stock = 200
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                    Name = "Minimalist Logo White T-Shirt",
                    Description = "Elevate your everyday look with our Minimalist Logo White T-Shirt. Featuring a subtle 'b' logo, this shirt is crafted from soft, breathable fabric for maximum comfort. Its clean design and modern aesthetic make it a versatile addition to any wardrobe, suitable for both casual and semi-formal occasions.",
                    Price = 18.50m,
                    ImageUrl = "https://images.unsplash.com/photo-1574180566232-aaad1b5b8450?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "T-Shirt",
                    Stock = 200
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    Name = "TAY SON Text Black T-Shirt",
                    Description = "Make a bold impression with our TAY SON Text Black T-Shirt. This shirt features a striking 'TAY SON' print on premium black fabric, offering both comfort and style. Its modern fit and durable material make it ideal for daily wear, while the unique design sets you apart from the crowd.",
                    Price = 18.50m,
                    ImageUrl = "https://images.unsplash.com/photo-1627225925683-1da7021732ea?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "T-Shirt",
                    Stock = 200
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    Name = "Skeleton Hand Graphic Black T-Shirt",
                    Description = "Stand out with our Skeleton Hand Graphic Black T-Shirt. Featuring a detailed graphic of a hand skeleton, this shirt is made from high-quality fabric for lasting comfort. Its edgy design and modern fit make it a perfect choice for those who appreciate unique, artistic apparel.",
                    Price = 28.50m,
                    ImageUrl = "https://images.unsplash.com/photo-1503341455253-b2e723bb3dbb?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjZ8fFQlMjBzaGlydHxlbnwwfHwwfHx8MA%3D%3D",
                    Category = "T-Shirt",
                    Stock = 200
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                    Name = "Elegant Silver Necklace",
                    Description = "Add a touch of sophistication to your ensemble with our Elegant Silver Necklace. Expertly crafted with a timeless design, this necklace complements both casual and formal attire. Its high-quality materials ensure durability and shine, making it a cherished accessory for years to come.",
                    Price = 50.50m,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1681276170423-2c60b95094b4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "Accessories",
                    Stock = 20
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                    Name = "Chic Straw Sun Hat",
                    Description = "Stay stylish and protected from the sun with our Chic Straw Sun Hat. This fashionable accessory is woven from high-quality straw, offering both durability and breathability. Its elegant design makes it perfect for beach outings, garden parties, or any sunny day adventure.",
                    Price = 30.99m,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1693221161784-e6a735e8e4b4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "Accessories",
                    Stock = 25
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                    Name = "Red Nike Athletic Shoes",
                    Description = "Step up your game with our Red Nike Athletic Shoes. Designed for both performance and style, these shoes feature advanced cushioning, a supportive fit, and a vibrant red color. Ideal for sports, workouts, or everyday wear, they provide the comfort and durability you expect from Nike.",
                    Price = 70.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=1740&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "Shoes",
                    Stock = 18
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                    Name = "Women's Classic Blue Jeans",
                    Description = "Discover timeless fashion with our Women's Classic Blue Jeans. Expertly tailored for a flattering fit, these jeans are made from premium denim that offers both comfort and durability. The classic blue wash and versatile design make them a must-have for any wardrobe, suitable for any occasion.",
                    Price = 20.00m,
                    ImageUrl = "https://images.unsplash.com/photo-1584370848010-d7fe6bc767ec?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Category = "Jeans",
                    Stock = 99
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
