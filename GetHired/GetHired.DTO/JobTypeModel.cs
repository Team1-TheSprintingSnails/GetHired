using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class JobTypeModel : IMapFrom<JobType>, IMapTo<JobType>
    {
        public string TypeName { get; set; }
    }
}