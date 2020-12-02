using Microsoft.EntityFrameworkCore;
using System;

namespace PS.Data.Context
{
    public class TaxCalcDbContext:DbContext
    {
        public TaxCalcDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<TaxResult> TaxResults { get; set; }
        public DbSet<TaxType>TaxTypes { get; set; }
    }
}
