using System.Collections.Generic;
using Bytes2you.Validation;
using GetHired.Core.Commands.Contracts;

namespace GetHired.Core.Commands
{
    public class AddJobOffer : ICommand
    {
        //private readonly IJobOfferService jobOfferService;

        //public AddJobOffer(IJobOfferService jobOfferService)
        //{
        //    //Guard.WhenArgument(jobOfferService, "jobOfferService").IsNull().Throw();

        //    //this.jobOfferService = jobOfferService;
        //}

        public string Execute(IList<string> parameters)
        {
            string position = parameters[0];
            string description = parameters[1];
            decimal payment = decimal.Parse(parameters[2]);
            string companyName = parameters[3];
            string jobTypeStr = parameters[4];
            string jobCategoryStr = parameters[5];

            // need to be fixed
            //var jobOfferModel = null;
            //this.jobOfferService.AddJobOffer(jobOfferModel);

            return $"Vehicle with ID 0 was created."; // also to be fixed
        }
    }
}
