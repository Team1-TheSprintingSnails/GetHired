using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class JobOfferModel : IMapTo<JobOffer>
    {
        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }
    }
}