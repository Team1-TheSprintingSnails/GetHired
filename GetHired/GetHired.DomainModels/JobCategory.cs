using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobCategory : IIdentifiable<int>, IModificationHistory
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

        public DateTime DataModified { get; set; }
        public DateTime DataCreated { get; set; }
    }
}
