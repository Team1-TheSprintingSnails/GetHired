using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.TeamFoundation.TestManagement.Client;
using GetHired.DomainModels.Enums;
using GetHired.DomainModels.Utilities;

namespace GetHired.DomainModels
{
    public class User : IIdentifiable<int>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public Role Role { get; set; }
        
        public virtual ICollection<JobType> DesiredJobTypes { get; set; }
        public virtual ICollection<JobCategory> DesiredJobCategories { get; set; }

        public virtual Password Password { get; set; }
    }
}
