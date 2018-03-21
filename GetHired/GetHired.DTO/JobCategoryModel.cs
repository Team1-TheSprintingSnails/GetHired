using GetHired.Common.Mapping;
using GetHired.DomainModels.Utilities;

namespace GetHired.DTO
{
    public class JobCategoryModel : IMapFrom<JobCategory>
    {
        public string CategoryName { get; set; }
    }
}
