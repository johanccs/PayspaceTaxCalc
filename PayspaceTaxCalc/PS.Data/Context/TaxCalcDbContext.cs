using Microsoft.EntityFrameworkCore;
using System;

namespace PS.Data.Context
{
    public class TaxCalcDbContext:DbContext
    {
        public TaxCalcDbContext(DbContextOptions<TaxCalcDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaxResult>().HasData(
                    new TaxResult
                    {
                        Id = 1,
                        AnnualIncome = 450000,
                        Date = DateTime.Now,
                        PostalCode = "6850",
                        Result = 36000
                    }
                );
        }

        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<TaxResult> TaxResults { get; set; }
        public DbSet<TaxType>TaxTypes { get; set; }

    }
}
