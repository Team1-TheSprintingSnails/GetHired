using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels.Utilities
{
    public class JobCategory : IIdentifiable<int>
    {
        private ICollection<JobOffer> jobOffers;

        public JobCategory()
        {
            this.JobOffers = new HashSet<JobOffer>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<JobOffer> JobOffers
        {
            get { return jobOffers; }
            set { jobOffers = value; }
        }
    }
}
