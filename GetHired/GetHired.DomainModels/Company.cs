﻿using System.Collections.Generic;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GetHired.DomainModels
{
    public class Company : IIdentifiable<int>
    {
        private ICollection<Address> addresses;
        private ICollection<JobOffer> jobOffers;

        public Company()
        {
            this.addresses = new HashSet<Address>();
            this.jobOffers = new HashSet<JobOffer>();
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

        public ICollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public ICollection<JobOffer> JobOffers
        {
            get { return jobOffers; }
            set { jobOffers = value; }
        }
    }
}