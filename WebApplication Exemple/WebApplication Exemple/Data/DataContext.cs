using Microsoft.EntityFrameworkCore;
using WebApplication_Exemple.Models;

namespace WebApplication_Exemple.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>();
        }



    }
}
