using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobCategoryModel : IMapFrom<JobCategory>, IMapTo<JobCategory>, IIdentifiable<int>
    {
        public int Id { get; }

        public string CategoryName { get; set; }
    }
}
