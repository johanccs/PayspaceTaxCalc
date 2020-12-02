using PS.Contracts.Repositories;
using PS.Repository.Mocks;

namespace PS.Repository
{
    public class MockRepositoryWrapper : IRepositoryWrapper
    {
        #region Fields

        private ITaxResultRepository _taxResultRepo;
        private ITaxTypeRepository _taxTypeRepo;
        private ITaxRateRepository _taxRateRepo;

        #endregion

        #region Properties

        public ITaxResultRepository TaxResultRepository
        {
            get
            {
                if (_taxResultRepo == null)
                {
                    _taxResultRepo = new MockTaxResultRepository();
                }

                return _taxResultRepo;
            }
        }
        public ITaxRateRepository TaxRateRepository
        {
            get
            {
                if (_taxRateRepo == null)
                {
                    _taxRateRepo = new MockTaxRateRepository();
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
                    _taxTypeRepo = new MockTaxTypeRepository();
                }

                return _taxTypeRepo;
            }
        }

        #endregion

        #region Methods

        public void Save()
        {
            return;
        }

        #endregion
    }
}
