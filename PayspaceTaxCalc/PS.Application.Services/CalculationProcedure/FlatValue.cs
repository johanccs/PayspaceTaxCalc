using PS.Data.DTO;
using System;

namespace PS.Application.Services.CalculationProcedure
{
    public class FlatValue : CalculationByType
    {
        public override decimal Calculate(TaxCalcDto taxCalc)
        {
            if (taxCalc.AnnualIncome < 0)
                throw new ArgumentException("Invalid negative annual income amount");

            if (taxCalc.AnnualIncome < 200000)
                return 10000;
            else
                return taxCalc.AnnualIncome * Convert.ToDecimal(0.05);
        }
    }
}
