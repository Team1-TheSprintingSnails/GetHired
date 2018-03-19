using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string BusinessInfo { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
