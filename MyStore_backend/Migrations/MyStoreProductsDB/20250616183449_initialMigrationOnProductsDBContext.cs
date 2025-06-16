using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore_backend.Migrations.MyStoreProductsDB
{
    /// <inheritdoc />
    public partial class initialMigrationOnProductsDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "T-Shirt", "A stylish white T-Shirt", "https://images.unsplash.com/photo-1512436991641-6745cdb1723f?auto=format&fit=crop&w=400&q=80", "Classic White T-Shirt", 29.99m, 99 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Jeans", "Classic blue denim jeans", "https://vilapuuvilla.fi/cdn/shop/products/0520bad2-dc50-40ae-9f90-afce00862eff_14094341_4429742_001_preview.jpg?v=1701160840", "Denim Jeans", 59.99m, 50 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Shoes", "Comfortable running sneakers", "https://pyxis.nymag.com/v1/imgs/a6d/fc0/4da4be21d1741718404660586a5b6a6f3e.jpg", "Running Sneakers", 89.99m, 30 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Accessories", "Premium brown leather wallet", "https://m.media-amazon.com/images/I/81WIcyHQ7oL._AC_UY1100_.jpg", "Leather Wallet", 39.99m, 40 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Hats", "Red adjustable baseball cap", "https://store.moma.org/cdn/shop/files/3a2b0b12-bde3-4a63-bba2-b561dbd7de29_5fa67989-c4a0-4bea-a74b-fb25ed894895.jpg?v=1710971142", "Baseball Cap", 19.99m, 60 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), new Guid("00000000-0000-0000-0000-000000000001"), 2, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), new Guid("00000000-0000-0000-0000-000000000002"), 1, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), new Guid("00000000-0000-0000-0000-000000000003"), 1, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), new Guid("00000000-0000-0000-0000-000000000004"), 3, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), new Guid("00000000-0000-0000-0000-000000000005"), 2, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), new Guid("00000000-0000-0000-0000-000000000001"), 1, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), new Guid("00000000-0000-0000-0000-000000000002"), 2, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), new Guid("00000000-0000-0000-0000-000000000003"), 2, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), new Guid("00000000-0000-0000-0000-000000000004"), 1, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("00000000-0000-0000-0000-000000000005"), 3, new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
