using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobType : IIdentifiable<int>, IModificationHistory
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

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
