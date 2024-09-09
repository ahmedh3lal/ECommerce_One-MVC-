using ECommerce_One.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace ECommerce_One.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Users>users { get; set; }   
        public DbSet<Product>products { get; set; }   
        public DbSet<Category>categories { get; set; }   
        public DbSet<Order>orders { get; set; }   
        public DbSet<Payment>payments { get; set; }   
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

    }
}
