using PS.Application.Services.CalculationProcedure;
using PS.Contracts.Repositories;
using PS.Contracts.Services;
using PS.Data;
using PS.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Application.Services
{
    public class CalculateTaxService : ICalculateTaxService
    {
        #region Readonly Fields

        private readonly IRepositoryWrapper _repoWrapper;

        #endregion

        #region Fields

        private CalculationManager _calcManager;

        #endregion

        #region Constructor

        public CalculateTaxService(IRepositoryWrapper repoWrapper, 
                                   CalculationManager calcManager)
        {
            _repoWrapper = repoWrapper;
            _calcManager = calcManager;
        }

        #endregion

        #region Methods
        public decimal Calculate(TaxCalcDto taxCalc)
        {
            if (taxCalc == null)
                throw new ArgumentException("Invalid TaxRate parameter");

            return _calcManager.Calculate(taxCalc);
        }

        #endregion

        #region Private Methods

        private IList<TaxRate>GetTaxRates()
        {
            var results = _repoWrapper.TaxRateRepository.GetAllResults();

            return results.ToList();
        }

        private IList<TaxType>GetTaxTypes()
        {
            var results = _repoWrapper.TaxTypeRepository.GetAllResults();

            return results.ToList();
        }

        #endregion
    }
}
