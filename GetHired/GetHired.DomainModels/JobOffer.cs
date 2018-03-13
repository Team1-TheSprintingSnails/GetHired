using GetHired.DomainModels.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobOffer : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public decimal Payment { get; set; }
        public JobType JobType { get; set; }
        public JobCategory JobCategory { get; set; }
        public int JobCompanyId { get; set; }
    }
}
