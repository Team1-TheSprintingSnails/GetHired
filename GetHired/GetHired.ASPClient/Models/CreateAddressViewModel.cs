using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.ASPClient.Models
{
    public class CreateAddressViewModel
    {
        public AddressWithCityDetailsModel AddressWithCityDetailsModel { get; set; }
        public IList<CityModel> Cities { get; set; }
    }
}