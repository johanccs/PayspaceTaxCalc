using PS.Data.DTO;

namespace PS.Application.Services.CalculationProcedure
{
    public abstract class CalculationByType
    {
        public abstract decimal Calculate(TaxCalcDto taxCalc);
    }
}
