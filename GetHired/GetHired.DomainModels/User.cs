using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class User : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}
