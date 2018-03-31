using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>, IMapTo<Company>, IHaveCustomMappings
    {
        public int CompanyId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string BusinessInfo { get; set; }

        [Required, MinLength(8), MaxLength(125)]
        public string Website { get; set; }

        [MinLength(10), MaxLength(10)]
        public string PhoneNumber { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Company, CompanyModel>()
                .ForMember(d => d.CompanyId, cfg => cfg.MapFrom(s => s.Id));

            configuration.CreateMap<CompanyModel, Company>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.CompanyId));
        }
    }
}