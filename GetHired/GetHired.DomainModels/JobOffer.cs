using System.Collections.Generic;
using GetHired.DomainModels.Utilities;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobOffer : IIdentifiable<int>
    {
        private ICollection<User> followers;

        public JobOffer()
        {
            this.Followers = new HashSet<User>();
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

        public ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }
    }
}
