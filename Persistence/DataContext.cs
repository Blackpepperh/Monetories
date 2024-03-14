using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //One Category to Many Sub-Categories
            builder.Entity<SubCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.CategoryId);

            //Transaction : AppUsers - Sub Categories
            builder.Entity<Transaction>(x => x.HasKey(t => new { t.AppUserId, t.SubCategoryId }));

            builder.Entity<Transaction>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.SubCategory)
            .HasForeignKey(x => x.AppUserId);

            builder.Entity<Transaction>()
            .HasOne(x => x.SubCategory)
            .WithMany(x => x.AppUser)
            .HasForeignKey(sc => sc.SubCategoryId);
        }
    }
}