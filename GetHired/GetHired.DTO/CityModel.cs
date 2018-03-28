using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class CityModel : IMapFrom<City>, IMapTo<City>, IHaveCustomMappings
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<City, CityModel>()
                .ForMember(d => d.CityId, cfg => cfg.MapFrom(s => s.Id));

            configuration.CreateMap<CityModel, City>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.CityId));
        }
    }
}