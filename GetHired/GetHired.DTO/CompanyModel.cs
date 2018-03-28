using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>, IMapTo<Company>, IHaveCustomMappings
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string BusinessInfo { get; set; }

        public string Website { get; set; }

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