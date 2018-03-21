using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels.Utilities
{
    public class JobType : IIdentifiable<int>
    {
        private ICollection<JobOffer> jobOffers;

        public JobType()
        {
            this.jobOffers = new HashSet<JobOffer>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<JobOffer> JobOffers
        {
            get { return jobOffers; }
            set { jobOffers = value; }
        }
    }
}
