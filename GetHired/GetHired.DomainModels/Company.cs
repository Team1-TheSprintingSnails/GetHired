using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string BusinessInfo { get; set; }
        public int ContactsId { get; set; }
        
    }
}
