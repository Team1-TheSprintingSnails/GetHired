using GetHired.Common.Mapping;
using GetHired.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHired.DTO
{
    public class AddressModel : IMapTo<Address>
    {
        public string Name { get; set; }
    }
}
