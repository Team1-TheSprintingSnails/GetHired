using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>, IMapTo<Company>
    {
        public string BusinessInfo { get; set; }

    }
}