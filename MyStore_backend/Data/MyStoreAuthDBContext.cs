using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyStore_backend.Data
{
    public class MyStoreAuthDBContext : IdentityDbContext
    {
        public MyStoreAuthDBContext(DbContextOptions<MyStoreAuthDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var customerId = "4df44424-6e2e-466e-a866-df56f08a67b1";
            var adminId = "79baa03c-c679-40cc-a3d4-a66d58f4932d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = customerId, Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp=customerId },
                new IdentityRole { Id = adminId, Name = "Admin", NormalizedName = "ADMIN",ConcurrencyStamp = adminId }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            // Seeded user: dummyuser@example.com
            // Password: Password123!
            var user1Id = "11111111-1111-1111-1111-111111111111";
            var user1 = new IdentityUser
            {
                Id = user1Id,
                UserName = "dummyuser@example.com",
                NormalizedUserName = "DUMMYUSER@EXAMPLE.COM",
                Email = "dummyuser@example.com",
                NormalizedEmail = "DUMMYUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEJv8QwQw1QwQw1QwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQw==",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // Seeded user: anotheruser@example.com
            // Password: Test@12345!
            var user2Id = "22222222-2222-2222-2222-222222222222";
            var user2 = new IdentityUser
            {
                Id = user2Id,
                UserName = "anotheruser@example.com",
                NormalizedUserName = "ANOTHERUSER@EXAMPLE.COM",
                Email = "anotheruser@example.com",
                NormalizedEmail = "ANOTHERUSER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEJQw1QwQw1QwQw1QwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQwQw==",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<IdentityUser>().HasData(user1, user2);
        }
    }
}
