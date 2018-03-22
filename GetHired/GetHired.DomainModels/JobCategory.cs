using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobCategory : IIdentifiable<int>, IModificationHistory
    {
        public JobCategory()
        {
            this.JobOffers = new HashSet<JobOffer>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
