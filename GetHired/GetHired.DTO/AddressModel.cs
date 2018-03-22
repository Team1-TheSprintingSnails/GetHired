using System.Security.Principal;
using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>, IMapTo<Address>, IIdentifiable<int>
    {
        public int Id { get; }

        public string Name { get; set; }
    }
}
