using Microsoft.EntityFrameworkCore;
using Products.Business.Domain;
using Products.Common.Types;

namespace Products.Business.Persistence;

public sealed class DataContext : DbContext
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<User> Users { get; set; }

    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../products.db");

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed the database with dummy data
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product Azul",
                Brand = "Brand Azul",
                Color = Color.Blue
            },
            new Product
            {
                Id = 2,
                Name = "Product Rojo",
                Brand = "Brand Rojo",
                Color = Color.Red
            },
            new Product
            {
                Id = 3,
                Name = "Product Verde",
                Brand = "Brand Verde",
                Color = Color.Green
            },
            new Product
            {
                Id = 4,
                Name = "Product Azul #2",
                Brand = "Brand Azul #2",
                Color = Color.Blue
            },
            new Product
            {
                Id = 5,
                Name = "Product Rojo #2",
                Brand = "Brand Rojo #2",
                Color = Color.Red
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
