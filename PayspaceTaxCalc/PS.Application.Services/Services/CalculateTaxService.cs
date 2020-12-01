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

        IRepositoryWrapper _repoWrapper;

        #endregion

        #region Constructor

        public CalculateTaxService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        #endregion

        #region Methods
        public decimal Calculate(TaxCalcDto taxCalc)
        {
            if (taxCalc == null)
                throw new ArgumentException("Invalid TaxRate parameter");

            decimal amtPayable = 0.00M;
            var taxRates = GetTaxRates();
            var taxTypes = GetTaxTypes();
            var taxType = taxTypes.FirstOrDefault(p => p.PostalCode.Equals(taxCalc.PostalCode));

            if (taxType.TaxCalculationType.Equals("Progressive"))
            {
                var taxRate = taxRates.FirstOrDefault(p => p.From < taxCalc.AnnualIncome && p.To > taxCalc.AnnualIncome);
                amtPayable = taxCalc.AnnualIncome * taxRate.Rate / Convert.ToDecimal(100);
            }
            else
            {
                //Flat Rate
                if(taxCalc.AnnualIncome > 10000 && taxCalc.AnnualIncome <= 200000)
                {
                    amtPayable = taxCalc.AnnualIncome * Convert.ToDecimal(0.05);
                }
                else
                {
                    amtPayable = taxCalc.AnnualIncome * Convert.ToDecimal(0.175);
                }
            }

            return amtPayable;
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
