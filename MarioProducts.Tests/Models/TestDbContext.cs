using Microsoft.EntityFrameworkCore;
using MarioProducts.Models;

namespace MarioProducts.Tests
{
    public class TestDbContext : MarioProductsDbContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=mario_products;uid=root;pwd=root;");
        }
    }
}
