using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels.Utilities
{
    public class JobType : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
