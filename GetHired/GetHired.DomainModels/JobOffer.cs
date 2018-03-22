using System;
using System.Collections.Generic;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobOffer : IIdentifiable<int>, IModificationHistory
    {
        public JobOffer()
        {
            this.LikedBy = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public decimal Payment { get; set; }
        public int CompanyId { get; set; }

        public int? JobTypeId { get; set; }
        public int? JobCategoryId { get; set; }
        
        public JobType JobType { get; set; }
        public JobCategory JobCategory { get; set; }
        public Company Company { get; set; }

        public ICollection<User> LikedBy { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
