using PS.Contracts.Repositories;
using PS.Data;
using PS.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace PS.Repository
{
    public class TaxTypeRepository : RepositoryBase<TaxType>, ITaxTypeRepository
    {
        #region Constructor
        public TaxTypeRepository(TaxCalcDbContext dbContext) :base(dbContext)
        {
        }

        #endregion

        #region Methods
        public IEnumerable<TaxType> GetAllResults()
        {
            return FindAll().ToList();
        }

        #endregion
    }
}
