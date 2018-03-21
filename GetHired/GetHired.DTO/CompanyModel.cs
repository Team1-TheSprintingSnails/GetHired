using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>
    {
        public string BusinessInfo { get; set; }

    }
}