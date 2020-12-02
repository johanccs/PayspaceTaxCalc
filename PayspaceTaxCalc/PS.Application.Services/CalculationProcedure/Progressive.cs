using PS.Data;
using PS.Data.DTO;
using System;

namespace PS.Application.Services.CalculationProcedure
{
    public class Progressive : CalculationByType
    {
        #region Private Readonly Field

        private readonly TaxRate _taxRate;

        #endregion

        #region Constructor

        public Progressive(TaxRate taxRate)
        {
            _taxRate = taxRate;
        }

        #endregion

        #region Methods

        public override decimal Calculate(TaxCalcDto taxCalc)
        {
            if (taxCalc.AnnualIncome < 0)
                throw new ArgumentException("Invalid negative annual income amount");

            return taxCalc.AnnualIncome * _taxRate.Rate / Convert.ToDecimal(100);
        }

        #endregion
    }
}
