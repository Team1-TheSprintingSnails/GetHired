using System.Collections.Generic;
using GetHired.DTO;

namespace GetHired.ASPClient.Models
{
    public class CompanyAddressesViewModel
    {
        public int CompanyId { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}