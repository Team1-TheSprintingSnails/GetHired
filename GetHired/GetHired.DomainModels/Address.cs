using System;
using System.ComponentModel.DataAnnotations;
using GetHired.DomainModels.Contracts;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class Address : IIdentifiable<int>, IModificationHistory
    {
        public int Id { get; set; }

        [Required, MinLength(5), MaxLength(125)]
        public string StreetName { get; set; }

        [Required, MaxLength(4)]
        public string PostalCode { get; set; }
        
        public int CityId { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public City City { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
