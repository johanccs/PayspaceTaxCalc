using AutoMapper;
using PS.Client.ServicesApi.QueryParameters;
using PS.Data.DTO;

namespace PS.Client.Api.AutomapProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxCalcParam.Get, TaxCalcDto>();
        }
    }
}
