namespace GetHired.DTO
{
    public class JobOfferModel //: IMapTo<JobOffer>
    {
        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }
    }
}