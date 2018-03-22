using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class TownModel : IMapFrom<Town>, IMapTo<Town>, IIdentifiable<int>
    {
        public int Id { get; }

        public string Name { get; set; }
    }
}