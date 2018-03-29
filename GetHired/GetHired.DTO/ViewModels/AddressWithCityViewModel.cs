using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO.ViewModels
{
    public class AddressWithCityViewModel : IMapFrom<Address>, IMapTo<Address>, IHaveCustomMappings
    {
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        [Index(IsUnique = true), Required, MinLength(4), MaxLength(4)]
        public string PostalCode { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int CompanyId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, AddressWithCityViewModel>()
                .ForMember(d => d.AddressId, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(d => d.CityName, cfg => cfg.MapFrom(d => d.City.Name))
                .ForMember(d => d.State, cfg => cfg.MapFrom(d => d.City.State))
                .ForMember(d => d.Country, cfg => cfg.MapFrom(d => d.City.Country));

            configuration.CreateMap<AddressWithCityViewModel, Address>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.AddressId));
        }
    }
}
