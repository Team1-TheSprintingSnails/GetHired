using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.ASPClient.Models
{
    public class CreateAddressViewModel
    {
        public AddressModel AddressModel { get; set; }
        public IList<CityModel> Cities { get; set; }
    }
}