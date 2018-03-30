using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class CityModel : IMapFrom<City>, IMapTo<City>, IHaveCustomMappings
    {
        public int CityId { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MinLength(2), MaxLength(50)]
        public string State { get; set; }

        [Required, MinLength(2), MaxLength(50)]
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