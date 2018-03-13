using System.Data.Entity;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;

namespace GetHired.DataModels
{
    public class GetHiredContext : DbContext
    {
        public GetHiredContext()
            : base("name=GetHired")
        {
            
        }
                                                                               

        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<JobOffer> JobOffers { get; set; }
        public virtual IDbSet<Town> Towns { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Contact> Contacts { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }
    }
}
