using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int>
    {
        private ICollection<Address> addresses;
        private ICollection<JobOffer> jobOffers;

        public Company()
        {
            this.addresses = new HashSet<Address>();
            this.jobOffers = new HashSet<JobOffer>();
        }
        public int Id { get; set; }
        public string BusinessInfo { get; set; }
        
        public virtual ContactInfo ContactInfo { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public virtual ICollection<JobOffer> JobOffers
        {
            get { return jobOffers; }
            set { jobOffers = value; }
        }
    }
}
