using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GetHired.DTO;
using Heroic.AutoMapper;

namespace GetHired.ASPClient.Models
{
    public class AddOrUpdateAddressViewModel : IMapFrom<AddressModel>
    {
        public int AddressId { get; set; }

        [Required, MinLength(5), MaxLength(125)]
        public string StreetName { get; set; }

        [Required, MinLength(4), MaxLength(4)]
        public string PostalCode { get; set; }

        public int CompanyId { get; set; }

        public int CityId { get; set; }

        public IEnumerable<CityModel> CitiesDropDownList { get; set; }
    }
}