using PS.Contracts.Repositories;
using PS.Contracts.Services;
using PS.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Readonly Fields

        private readonly TaxCalcDbContext _taxCalcDbContext;

        #endregion

        #region Fields

        private ITaxResultRepository _taxResultRepo;
     
        #endregion

        #region Constructor

        public RepositoryWrapper(TaxCalcDbContext taxCalcDbContext)
        {
            _taxCalcDbContext = taxCalcDbContext;
        }

        #endregion

        public ITaxResultRepository TaxResultRepository
        {
            get
            {
                if(_taxResultRepo == null)
                {
                    _taxResultRepo = new TaxResultRepository(_taxCalcDbContext);
                }

                return _taxResultRepo;
            }
        }

        public void Save()
        {
            _taxCalcDbContext.SaveChanges();
        }
    }
}
