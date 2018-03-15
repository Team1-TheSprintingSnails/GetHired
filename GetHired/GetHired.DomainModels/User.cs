using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.ComponentModel.DataAnnotations.Schema;
using GetHired.DomainModels.Enums;

namespace GetHired.DomainModels
{
    public class User : IIdentifiable<int>
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string ContactsId { get; set; }

        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
