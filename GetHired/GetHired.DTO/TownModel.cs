using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class TownModel : IMapFrom<Town>
    {
        public string Name { get; set; }
    }
}