using PS.Contracts.Repositories;
using PS.Data;
using System.Collections.Generic;

namespace PS.Repository.Mocks
{
    public class MockTaxTypeRepository : ITaxTypeRepository
    {
        public IEnumerable<TaxType> GetAllResults()
        {
            var results = new List<TaxType>
            {
                new TaxType{Id = 0, PostalCode = "7441", TaxCalculationType = "Progressive"},
                new TaxType{Id = 1, PostalCode = "A100", TaxCalculationType = "Flat Value"},
                new TaxType{Id = 2, PostalCode = "7000", TaxCalculationType = "Flat Rate"},
                new TaxType{Id = 3, PostalCode = "1000", TaxCalculationType = "Progressive"},
            };

            return results;
        }
    }
}
