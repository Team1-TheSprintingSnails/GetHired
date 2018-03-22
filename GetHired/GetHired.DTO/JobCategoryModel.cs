using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class JobCategoryModel : IMapFrom<JobCategory>, IMapTo<JobCategory>
    {
        public string CategoryName { get; set; }
    }
}
