using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class ContactInfo : IIdentifiable<int>
    {
        [Key]
        [ForeignKey("Company")]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "The phone is required")]
        [Phone(ErrorMessage = "The phone number is incorrect")]
        public string PhoneNumber { get; set; }

        public virtual Company Company { get; set; }
    }
}
