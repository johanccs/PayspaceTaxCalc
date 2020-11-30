using AutoMapper;
using PS.Client.Web.Models;
using PS.Data.DTO;

namespace PS.Client.Web.AutomapProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxCalculationModel, TaxCalcDto>();
        }
    }
}
