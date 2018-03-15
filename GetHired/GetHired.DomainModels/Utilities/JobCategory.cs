using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels.Utilities
{
    public class JobCategory : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
