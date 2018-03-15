using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Address : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownId { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual Town Town { get; set; }
    }
}
