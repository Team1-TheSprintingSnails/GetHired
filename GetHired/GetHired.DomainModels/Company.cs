using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GetHired.DomainModels.Contracts;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int> , IModificationHistory
    {
        public Company()
        {
            this.Addresses = new HashSet<Address>();
            this.JobOffers = new HashSet<JobOffer>();
        }
        public int Id { get; set; }
        public string BusinessInfo { get; set; }

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

        public ICollection<Address> Addresses { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}