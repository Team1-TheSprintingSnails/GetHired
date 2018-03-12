using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Town : IIdentifiable<int>
    {
        public int Id { get; set; }
    }
}
