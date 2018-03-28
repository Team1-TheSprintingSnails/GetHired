using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GetHired.DomainModels.Contracts;
using GetHired.DomainModels.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class JobOffer : IIdentifiable<int>, IModificationHistory
    {
        public JobOffer()
        {
            this.LikedBy = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Position { get; set; }
        
        public string Description { get; set; }

        public decimal Payment { get; set; }

        public int CompanyId { get; set; }

        public decimal Rating { get; set; }
        
        public JobType JobType { get; set; }

        public JobCategory JobCategory { get; set; }

        public Company Company { get; set; }

        public ICollection<User> LikedBy { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
