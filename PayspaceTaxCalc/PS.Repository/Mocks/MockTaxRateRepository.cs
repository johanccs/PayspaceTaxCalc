using PS.Contracts.Repositories;
using PS.Data;
using System.Collections.Generic;

namespace PS.Repository.Mocks
{
    public class MockTaxRateRepository : ITaxRateRepository
    {
        public IEnumerable<TaxRate> GetAllResults()
        {
            var results = new List<TaxRate>{
                new TaxRate { Id = 0, Rate = 10, From = 0, To = 8350 },
                new TaxRate { Id = 1, Rate = 15, From = 8351, To = 33950 },
                new TaxRate { Id = 2, Rate = 25, From = 33951, To = 82250 },
            };

            return results;
        }
    }
}
