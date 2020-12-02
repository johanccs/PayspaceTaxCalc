using System;
using System.Linq;
using System.Linq.Expressions;

namespace PS.Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> where);

        void Create(T entity);
        void Delete(T entity);
    }
}
