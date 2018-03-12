using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Contact : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}
