using PS.Data.DTO;
using System;

namespace PS.Application.Services.CalculationProcedure
{
    public class FlatRate : CalculationByType
    {
        public override decimal Calculate(TaxCalcDto taxCalc)
        {
            if (taxCalc.AnnualIncome < 0)
                throw new ArgumentException("Invalid negative annual income amount");

           return taxCalc.AnnualIncome * Convert.ToDecimal(0.175);
        }
    }
}
