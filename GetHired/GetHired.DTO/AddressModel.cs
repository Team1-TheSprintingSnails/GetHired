using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>, IMapTo<Address>, IHaveCustomMappings
    {
        public int AddressId { get; set; }

        [Required, MinLength(5), MaxLength(125)]
        public string StreetName { get; set; }

        [Required, MinLength(4), MaxLength(4)]
        public string PostalCode { get; set; }

        public int CompanyId { get; set; }
        
        public int CityId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, AddressModel>()
                .ForMember(d => d.AddressId, cfg => cfg.MapFrom(s => s.Id));

            configuration.CreateMap<AddressModel, Address>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.AddressId));
        }
    }
}