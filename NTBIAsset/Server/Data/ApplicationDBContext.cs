using Microsoft.EntityFrameworkCore;
using NTBIAsset.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTBIAsset.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options ):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>().Property(x => x.BarCode).HasComputedColumnSql("('FXT'+right('0000000'+CONVERT([varchar](6),[Id],(0)),(7)))");
            modelBuilder.Entity<Trail>()
                        .Property(b => b.Date_Action)
                        .HasColumnType("smalldatetime")
                        .HasDefaultValueSql("getdate()"); 
            modelBuilder.Entity<UserAccount>()
                        .Property(b => b.Date_Created)
                        .HasColumnType("smalldatetime")
                        .HasDefaultValueSql("getdate()");
        }

        public DbSet<Stock> stocks { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Trail> trails { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }

    }
}
