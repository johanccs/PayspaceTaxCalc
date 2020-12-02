using Microsoft.EntityFrameworkCore;
using PS.Contracts.Repositories;
using PS.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PS.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Fields

        private TaxCalcDbContext _dbContext;

        #endregion

        #region Constructor

        public RepositoryBase(TaxCalcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).AsNoTracking();
        }

        #endregion
    }
}
