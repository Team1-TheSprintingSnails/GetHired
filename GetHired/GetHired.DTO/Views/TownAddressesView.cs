using System.Collections.Generic;

namespace GetHired.DTO.Views
{
    public class TownAddressesView
    {
        public TownModel Town { get; set; }
        
        public ICollection<AddressModel> Addresses { get; set; }
    }
}
