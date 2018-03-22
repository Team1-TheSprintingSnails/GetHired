using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>, IMapTo<Company>, IIdentifiable<int>
    {
        public int Id { get; }

        public string BusinessInfo { get; set; }
    }
}