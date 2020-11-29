using PS.Data.DTO;

namespace PS.Contracts.Services
{
    public interface ICalculateTaxService
    {
        decimal Calculate(TaxCalcDto taxRate);
    }
}
