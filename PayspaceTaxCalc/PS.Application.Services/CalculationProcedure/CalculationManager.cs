using PS.Application.Services.Enumerations;
using PS.Contracts.Repositories;
using PS.Data;
using PS.Data.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PS.Application.Services.CalculationProcedure
{
    public class CalculationManager
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CalculationManager(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        #region Methods

        public decimal Calculate(TaxCalcDto taxCalcDto)
        {
            var taxRates = GetTaxRates();
            var taxTypes = GetTaxTypes();
            var taxType = taxTypes.FirstOrDefault(p => p.PostalCode.Equals(taxCalcDto.PostalCode));

            CalculationByType calcByType;

            try
            {
                if (taxType.TaxCalculationType.Equals(TaxConstants.PROGRESSIVE))
                {
                    var taxRate = taxRates.FirstOrDefault(
                        p => p.From <= taxCalcDto.AnnualIncome && p.To >= taxCalcDto.AnnualIncome);

                    calcByType = new Progressive(taxRate);
                }
                else if (taxType.TaxCalculationType.Equals(TaxConstants.FLATRATE))
                {
                    calcByType = new FlatRate();
                }
                else
                {
                    calcByType = new FlatValue();
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            return calcByType.Calculate(taxCalcDto);
        }

        #endregion

        #region Private Methods

        private IList<TaxRate> GetTaxRates()
        {
            var results = _repoWrapper.TaxRateRepository.GetAllResults();

            return results.ToList();
        }

        private IList<TaxType> GetTaxTypes()
        {
            var results = _repoWrapper.TaxTypeRepository.GetAllResults();

            return results.ToList();
        }

        #endregion
    }
}
