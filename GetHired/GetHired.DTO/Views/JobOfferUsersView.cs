using System.Collections.Generic;

namespace GetHired.DTO.Views
{
    public class JobOfferUsersView
    {
        public JobOfferModel JobOffer { get; set; }

        public JobTypeModel JobType { get; set; }

        public JobCategoryModel JobCategory { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
