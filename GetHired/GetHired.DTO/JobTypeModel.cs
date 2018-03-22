using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobTypeModel : IMapFrom<JobType>, IMapTo<JobType>, IIdentifiable<int>
    {
        public int Id { get; }

        public string TypeName { get; set; }
    }
}