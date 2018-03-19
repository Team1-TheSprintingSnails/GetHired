using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Password : IIdentifiable<int>
    {
        [ForeignKey("User")]
        public int Id { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual User User { get; set; }
    }
}