using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore_backend.Migrations.MyStoreProductsDB
{
    /// <inheritdoc />
    public partial class updateProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience timeless style and comfort with our Premium Classic White T-Shirt. Crafted from high-quality, breathable cotton, this versatile piece is perfect for any occasion, whether you're dressing up or keeping it casual. Its tailored fit and soft fabric ensure all-day comfort, making it a staple in any modern wardrobe.", "Premium Classic White T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Our Signature Blue Denim Jeans offer a classic look with a modern twist. Made from durable, premium denim, these jeans provide a comfortable fit and exceptional longevity. The timeless blue wash and expert tailoring make them suitable for both casual outings and more formal settings, ensuring you always look your best.", "Signature Blue Denim Jeans" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Achieve your fitness goals with our Elite Performance Running Sneakers. Engineered for maximum comfort and support, these sneakers feature advanced cushioning technology and a lightweight, breathable design. Perfect for both daily runs and casual wear, they deliver superior traction and durability for any activity.", "Elite Performance Running Sneakers" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Keep your essentials organized in style with our Luxury Brown Leather Wallet. Handcrafted from premium genuine leather, this wallet features multiple card slots, a spacious bill compartment, and a sleek, elegant design. Its rich brown color and fine stitching make it a sophisticated accessory for any professional.", "Luxury Brown Leather Wallet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Add a pop of color to your outfit with our Adjustable Red Baseball Cap. Designed for comfort and style, this cap features a customizable fit, breathable fabric, and a classic curved brim. Ideal for outdoor activities or casual wear, it offers both sun protection and a fashionable look.", "Adjustable Red Baseball Cap" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000006"), "T-Shirt", "Showcase your playful side with our Artisan Cat Graphic White T-Shirt. Made from ultra-soft cotton, this shirt features a unique, artist-designed cat graphic that adds personality to your wardrobe. Its comfortable fit and eye-catching design make it perfect for both casual outings and relaxed weekends.", "https://images.unsplash.com/photo-1576566588028-4147f3842f27?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8VCUyMHNoaXJ0fGVufDB8fDB8fHww", "Artisan Cat Graphic White T-Shirt", 29.99m, 99 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "T-Shirt", "Express your creativity with our Modern Art Text Black T-Shirt. This premium tee features a bold, artistic text design on high-quality black fabric. Its contemporary style and comfortable fit make it a standout piece for anyone looking to make a statement while enjoying all-day comfort.", "https://images.unsplash.com/photo-1583744946564-b52ac1c389c8?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fFQlMjBzaGlydHxlbnwwfHwwfHx8MA%3D%3D", "Modern Art Text Black T-Shirt", 15.00m, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "T-Shirt", "Elevate your everyday look with our Minimalist Logo White T-Shirt. Featuring a subtle 'b' logo, this shirt is crafted from soft, breathable fabric for maximum comfort. Its clean design and modern aesthetic make it a versatile addition to any wardrobe, suitable for both casual and semi-formal occasions.", "https://images.unsplash.com/photo-1574180566232-aaad1b5b8450?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Minimalist Logo White T-Shirt", 18.50m, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "T-Shirt", "Make a bold impression with our TAY SON Text Black T-Shirt. This shirt features a striking 'TAY SON' print on premium black fabric, offering both comfort and style. Its modern fit and durable material make it ideal for daily wear, while the unique design sets you apart from the crowd.", "https://images.unsplash.com/photo-1627225925683-1da7021732ea?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "TAY SON Text Black T-Shirt", 18.50m, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "T-Shirt", "Stand out with our Skeleton Hand Graphic Black T-Shirt. Featuring a detailed graphic of a hand skeleton, this shirt is made from high-quality fabric for lasting comfort. Its edgy design and modern fit make it a perfect choice for those who appreciate unique, artistic apparel.", "https://images.unsplash.com/photo-1503341455253-b2e723bb3dbb?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjZ8fFQlMjBzaGlydHxlbnwwfHwwfHx8MA%3D%3D", "Skeleton Hand Graphic Black T-Shirt", 28.50m, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Accessories", "Add a touch of sophistication to your ensemble with our Elegant Silver Necklace. Expertly crafted with a timeless design, this necklace complements both casual and formal attire. Its high-quality materials ensure durability and shine, making it a cherished accessory for years to come.", "https://plus.unsplash.com/premium_photo-1681276170423-2c60b95094b4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Elegant Silver Necklace", 50.50m, 20 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Accessories", "Stay stylish and protected from the sun with our Chic Straw Sun Hat. This fashionable accessory is woven from high-quality straw, offering both durability and breathability. Its elegant design makes it perfect for beach outings, garden parties, or any sunny day adventure.", "https://plus.unsplash.com/premium_photo-1693221161784-e6a735e8e4b4?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Chic Straw Sun Hat", 30.99m, 25 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Shoes", "Step up your game with our Red Nike Athletic Shoes. Designed for both performance and style, these shoes feature advanced cushioning, a supportive fit, and a vibrant red color. Ideal for sports, workouts, or everyday wear, they provide the comfort and durability you expect from Nike.", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?q=80&w=1740&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Red Nike Athletic Shoes", 70.00m, 18 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Jeans", "Discover timeless fashion with our Women's Classic Blue Jeans. Expertly tailored for a flattering fit, these jeans are made from premium denim that offers both comfort and durability. The classic blue wash and versatile design make them a must-have for any wardrobe, suitable for any occasion.", "https://images.unsplash.com/photo-1584370848010-d7fe6bc767ec?q=80&w=774&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Women's Classic Blue Jeans", 20.00m, 99 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A stylish white T-Shirt", "Classic White T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Classic blue denim jeans", "Denim Jeans" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Comfortable running sneakers", "Running Sneakers" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Premium brown leather wallet", "Leather Wallet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Red adjustable baseball cap", "Baseball Cap" });
        }
    }
}
