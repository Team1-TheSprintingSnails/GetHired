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
        
        [Index(IsUnique = true), Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
        
        public string BusinessInfo { get; set; }
        
        [Index(IsUnique = true), Required, MinLength(8), MaxLength(125)]
        public string Website { get; set; }

        [MinLength(10), MaxLength(10)]
        public string PhoneNumber { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}