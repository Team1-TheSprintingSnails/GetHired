using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;
using GetHired.DomainModels.Enums;

namespace GetHired.DomainModels
{
    public class User : IIdentifiable<int>, IModificationHistory
    {
        public User()
        {
            this.SavedJobOffers = new HashSet<JobOffer>();
        }

        public int Id { get; set; }
        
        [Required, MinLength(8), MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(50)]
        public string MiddleName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime? DataOfBirth { get; set; }

        [Required]
        public Role Role { get; set; }

        public ICollection<JobOffer> SavedJobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
