using System.Collections;
using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.ASPClient.Models
{
    public class AddressViewModel
    {
        public AddressModel Address { get; set; }
        public IList<CityModel> Cities { get; set; }
    }
}