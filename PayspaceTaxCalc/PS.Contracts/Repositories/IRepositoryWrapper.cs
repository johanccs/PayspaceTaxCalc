namespace PS.Contracts.Repositories
{
    public interface IRepositoryWrapper
    {
        ITaxResultRepository TaxResultRepository { get; }
        ITaxRateRepository TaxRateRepository { get; }
        ITaxTypeRepository TaxTypeRepository { get; } 
        void Save();
    }
}
