using GetHired.Common.Mapping;
using GetHired.DomainModels.Utilities;

namespace GetHired.DTO
{
    public class JobTypeModel : IMapFrom<JobType>
    {
        public string TypeName { get; set; }

    }
}