using PS.Contracts.Repositories;
using PS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PS.Repository.Mocks
{
    public class MockTaxResultRepository : ITaxResultRepository
    {
        public void Create(TaxResult entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaxResult entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaxResult> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaxResult> FindByCondition(Expression<Func<TaxResult, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaxResult> GetAllResults()
        {
            throw new NotImplementedException();
        }
    }
}
