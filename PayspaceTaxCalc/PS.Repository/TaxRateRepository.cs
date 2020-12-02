using PS.Contracts.Repositories;
using PS.Data;
using PS.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace PS.Repository
{
    public class TaxRateRepository : RepositoryBase<TaxRate>, ITaxRateRepository
    {
        #region Constructor

        public TaxRateRepository(TaxCalcDbContext dbContext):base(dbContext)
        {}

        #endregion

        #region Methods

        public IEnumerable<TaxRate> GetAllResults()
        {
            return FindAll().OrderBy(p=>p.Rate);
        }

        #endregion
    }
}
