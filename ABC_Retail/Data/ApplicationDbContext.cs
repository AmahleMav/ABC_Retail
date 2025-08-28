using ABC_Retail.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Products
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Name = "Nike Cortiez Air Max 95",
                    Description = "Sleek black sneakers with a layered design and visible Air Max cushioning, offering comfort and street-ready style.",
                    Price = 4400.00m,
                    ImageUrl = "https://retailstoreabc.blob.core.windows.net/productimage/CoteizAirMax95.png"
                },
                new Products
                {
                    Id = 2,
                    Name = "Nike ShoX TL",
                    Description = "Crisp white athletic shoes featuring Nike’s Shox cushioning columns for responsive impact protection.",
                    Price = 3300.00m,
                    ImageUrl = "https://retailstoreabc.blob.core.windows.net/productimage/NikeShoX.png"
                },
                new Products
                {
                    Id = 3,
                    Name = "Nike Air Force 1",
                    Description = "Classic low-top silhouette with a clean white and grey colorway, iconic for its durable leather and versatile style.",
                    Price = 2400.00m,
                    ImageUrl = "https://retailstoreabc.blob.core.windows.net/productimage/NikeAirForce1.jpg"
                },
                 new Products
                 {
                     Id = 4,
                     Name = "New Balance 1000",
                     Description = "Retro-inspired running shoes with premium grey and silver tones, known for cushioning and timeless appeal.",
                     Price = 3400.00m,
                     ImageUrl = "https://retailstoreabc.blob.core.windows.net/productimage/NewBalance1000.jpg"
                 }
            );
        }
    }
}
