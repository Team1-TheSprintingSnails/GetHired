using System;
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
        private ICollection<JobOffer> favouriteJobOffers;

        public User()
        {
            this.favouriteJobOffers = new HashSet<JobOffer>();
        }

        [Key]
        public int Id { get; set; }
        
        [MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        [MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public Role Role { get; set; }

        public ICollection<JobOffer> FavouriteJobOffers
        {
            get { return favouriteJobOffers; }
            set { favouriteJobOffers = value; }
        }
    }
}
