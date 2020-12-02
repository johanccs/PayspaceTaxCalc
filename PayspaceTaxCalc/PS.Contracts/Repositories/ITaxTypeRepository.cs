using PS.Data;
using System.Collections.Generic;

namespace PS.Contracts.Repositories
{
    public interface ITaxTypeRepository
    {
        IEnumerable<TaxType> GetAllResults();
    }
}
