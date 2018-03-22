using GetHired.DomainModels;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobOfferModel : IMapFrom<JobOffer>, IMapTo<JobOffer>, IIdentifiable<int>
    {
        public int Id { get; }

        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }
    }
}