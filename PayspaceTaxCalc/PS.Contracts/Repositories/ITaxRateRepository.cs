using PS.Data;
using System.Collections.Generic;

namespace PS.Contracts.Repositories
{
    public interface ITaxRateRepository
    {
        IEnumerable<TaxRate> GetAllResults();
    }
}
