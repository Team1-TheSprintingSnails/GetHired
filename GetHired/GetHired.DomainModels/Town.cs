using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Town : IIdentifiable<int>
    {
        private ICollection<Address> addresses;

        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
    }
}
