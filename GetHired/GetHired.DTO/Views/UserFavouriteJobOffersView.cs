using System.Collections.Generic;

namespace GetHired.DTO.Views
{
    public class UserFavouriteJobOffersView
    {
        public ICollection<JobOfferModel> Favourites { get; set; }

        public UserModel User { get; set; }
    }
}
