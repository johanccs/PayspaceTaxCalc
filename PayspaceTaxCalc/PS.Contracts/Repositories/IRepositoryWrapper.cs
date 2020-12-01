using PS.Contracts.Services;

namespace PS.Contracts.Repositories
{
    public interface IRepositoryWrapper
    {
        ITaxResultRepository TaxResultRepository { get; }
     
        void Save();
    }
}
