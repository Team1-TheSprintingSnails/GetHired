using GetHired.DomainModels.Utilities;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobOffer : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public decimal Payment { get; set; }
        public int CompanyId { get; set; }

        public int? JobTypeId { get; set; }
        public int? JobCategoryId { get; set; }
        
        public virtual JobType JobType { get; set; }
        public virtual JobCategory JobCategory { get; set; }
        public virtual Company Company { get; set; }
    }
}
