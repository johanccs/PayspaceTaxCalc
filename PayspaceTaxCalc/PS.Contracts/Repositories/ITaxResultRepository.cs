using PS.Data;
using System.Collections.Generic;

namespace PS.Contracts.Repositories
{
    public interface ITaxResultRepository: IRepositoryBase<TaxResult>
    {
        IEnumerable<TaxResult> GetAllResults();
    }
}
