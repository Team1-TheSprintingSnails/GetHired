using System.Linq;
using GetHired.DTO;

namespace GetHired.Services.Contracts
{
    public interface IJobOfferService
    {
        void AddJobOffer(JobOfferModel jobOffer);

        IQueryable<JobOfferModel> GetAllJobOffers();
    }
}
