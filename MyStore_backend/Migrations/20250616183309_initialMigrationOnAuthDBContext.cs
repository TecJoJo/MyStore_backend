using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore_backend.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationOnAuthDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "99a392e1-5e46-4fe2-8bde-49d6b263d7b9", "dummyuser@example.com", true, false, null, "DUMMYUSER@EXAMPLE.COM", "DUMMYUSER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJv8QwQw1QwQw1QwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQw==", null, false, "a28a5ad0-3a16-47c0-adb8-6410be907048", false, "dummyuser@example.com" },
                    { "22222222-2222-2222-2222-222222222222", 0, "b7701d3f-e017-4c4b-ba2c-425fe47c6626", "anotheruser@example.com", true, false, null, "ANOTHERUSER@EXAMPLE.COM", "ANOTHERUSER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJQw1QwQw1QwQw1QwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQw==", null, false, "c90f0200-8774-4dcb-9e05-694ee3e8bf99", false, "anotheruser@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222");
        }
    }
}
