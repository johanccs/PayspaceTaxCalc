using PS.Contracts.Repositories;
using PS.Data.Context;
using System;

namespace PS.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Readonly Fields

        private readonly TaxCalcDbContext _taxCalcDbContext;

        #endregion

        #region Fields

        private ITaxResultRepository _taxResultRepo;
        private ITaxTypeRepository _taxTypeRepo;
        private ITaxRateRepository _taxRateRepo;
     
        #endregion

        #region Constructor

        public RepositoryWrapper(TaxCalcDbContext taxCalcDbContext)
        {
            _taxCalcDbContext = taxCalcDbContext;
        }

        #endregion

        #region Properties

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
        public ITaxRateRepository TaxRateRepository
        {
            get
            {
                if(_taxRateRepo == null)
                {
                    _taxRateRepo = new TaxRateRepository(_taxCalcDbContext);
                }

                return _taxRateRepo;
            }
        }        
        public ITaxTypeRepository TaxTypeRepository
        {
            get
            {
                if (_taxTypeRepo == null)
                {
                    _taxTypeRepo = new TaxTypeRepository(_taxCalcDbContext);
                }

                return _taxTypeRepo;
            }
        }

        #endregion

        #region Methods
        
        public void Save()
        {
            _taxCalcDbContext.SaveChanges();
        }
       
        #endregion
    }
}
