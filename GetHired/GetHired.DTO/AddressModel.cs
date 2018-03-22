using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>, IMapTo<Address>
    {
        public string Name { get; set; }
    }
}
