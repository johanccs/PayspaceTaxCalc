using PS.Contracts.Repositories;
using PS.Data;
using PS.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace PS.Repository
{
    public class TaxResultRepository: RepositoryBase<TaxResult>, ITaxResultRepository
    {
        #region Constructor

        public TaxResultRepository(TaxCalcDbContext dbContext):base(dbContext)
        {}

        #endregion

        #region Methods

        public IEnumerable<TaxResult> GetAllResults()
        {
            return FindAll().OrderBy(ob => ob.Date);
        }

        #endregion
    }
}
