using Microsoft.EntityFrameworkCore;
using recipeapp_backend.Models;

namespace recipeapp_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recipes> Recipes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.Recipes)
            //     .WithMany(r => r.Orders);
            // modelBuilder.Entity<Ingredients>()
            //     .HasOne(i => i.Recipes)
            //     .WithMany(r => r.Ingredientses);
            // base.OnModelCreating(modelBuilder);
        }
    }
}