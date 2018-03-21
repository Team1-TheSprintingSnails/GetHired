using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>
    {
        public string Name { get; set; }
    }
}
