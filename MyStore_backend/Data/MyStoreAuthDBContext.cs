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
        }
    }
}
