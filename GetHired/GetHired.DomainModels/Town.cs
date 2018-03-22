using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Town : IIdentifiable<int>, IModificationHistory
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
