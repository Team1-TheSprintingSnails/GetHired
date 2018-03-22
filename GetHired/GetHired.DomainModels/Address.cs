using System;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Address : IIdentifiable<int>, IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public Town Town { get; set; }

        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
    }
}
