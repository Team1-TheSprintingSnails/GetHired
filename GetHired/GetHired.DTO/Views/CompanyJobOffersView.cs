using System.Collections.Generic;

namespace GetHired.DTO.Views
{
    public class CompanyJobOffersView
    {
        public CompanyModel Company { get; set; }

        public ICollection<JobOfferModel> JobOffers { get; set; }

    }
}
