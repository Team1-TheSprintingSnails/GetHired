using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class TownModel : IMapFrom<Town>, IMapTo<Town>
    {
        public string Name { get; set; }
    }
}