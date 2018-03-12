using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}
