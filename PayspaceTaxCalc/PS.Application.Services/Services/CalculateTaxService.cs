using PS.Contracts.Services;
using PS.Data.DTO;
using System;

namespace PS.Application.Services
{
    public class CalculateTaxService : ICalculateTaxService
    {
        #region Constructor

        public CalculateTaxService()
        {

        }

        #endregion

        #region Methods

        public decimal Calculate(TaxCalcDto taxRate)
        {
            if (taxRate == null)
                throw new ArgumentException("Invalid TaxRate parameter");

            return taxRate.AnnualIncome * Convert.ToDecimal(0.15);
        }

        #endregion
    }
}
