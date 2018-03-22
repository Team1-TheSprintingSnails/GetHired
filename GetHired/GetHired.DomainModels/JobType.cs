using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobType : IIdentifiable<int>, IModificationHistory
    {
        public JobType()
        {
            this.JobOffers = new HashSet<JobOffer>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
