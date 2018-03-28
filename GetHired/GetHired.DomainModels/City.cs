using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DomainModels
{
    public class City : IIdentifiable<int>
    {
        public City()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MinLength(2), MaxLength(50)]
        public string State { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Country { get; set; }
        
        public ICollection<Address> Addresses { get; set; }
    }
}
