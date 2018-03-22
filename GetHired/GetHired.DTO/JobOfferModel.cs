using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class JobOfferModel : IMapFrom<JobOffer>, IMapTo<JobOffer>
    {
        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }
    }
}