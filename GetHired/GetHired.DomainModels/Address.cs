using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Address : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public Town Town { get; set; }
    }
}
