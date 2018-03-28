using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>, IMapTo<Address>, IHaveCustomMappings
    {
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        public string PostalCode { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int CompanyId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, AddressModel>()
                .ForMember(d => d.AddressId, cfg => cfg.MapFrom(s => s.Id));

            configuration.CreateMap<AddressModel, Address>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.AddressId));
        }
    }
}
