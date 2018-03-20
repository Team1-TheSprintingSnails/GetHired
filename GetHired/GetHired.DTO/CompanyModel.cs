using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class CompanyModel : IMapTo<Company>
    {
        public string BusinessInfo { get; set; }
    }
}