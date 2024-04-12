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
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Account : AppUsers - Currencies
            // builder.Entity<Account>(x => x.HasKey(a => new { a.AccountId, a.CurrencyId, a.AppUserId }));

            builder.Entity<Account>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.Currencies)
            .HasForeignKey(x => x.AppUserId);

            builder.Entity<Account>()
            .HasOne(x => x.Currency)
            .WithMany(x => x.AppUsers)
            .HasForeignKey(x => x.CurrencyId);

            //Account - TransactionHeader
            builder.Entity<TransactionHeader>()
            .HasOne(x => x.Account)
            .WithMany(x => x.TransactionHeaders)
            .HasForeignKey(x => x.AccountId);

            //TransactionDetail : TransactionHeaders - Categories
            builder.Entity<TransactionDetail>()
            .HasOne(td => td.TransactionHeader)
            .WithMany(th => th.Categories)
            .HasForeignKey(td => td.TransactionHeaderId);

            builder.Entity<TransactionDetail>()
            .HasOne(td => td.Category)
            .WithMany(c => c.TransactionHeaders)
            .HasForeignKey(td => td.CategoryId);
        }
    }
}