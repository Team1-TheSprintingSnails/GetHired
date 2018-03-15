using System.Data.Entity;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.DomainModels.Utilities;

namespace GetHired.DataModels
{
    public class GetHiredContext : DbContext, IGetHiredContext
    {
        public GetHiredContext()
            : base("name=GetHired")
        { }                                         

        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<JobOffer> JobOffers { get; set; }
        public virtual IDbSet<Town> Towns { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<ContactInfo> Contacts { get; set; }
        public virtual IDbSet<Company> Companies { get; set; }
        public virtual IDbSet<JobType> JobTypes { get; set; }
        public virtual IDbSet<JobCategory> JobCategories { get; set; }
    }
}
