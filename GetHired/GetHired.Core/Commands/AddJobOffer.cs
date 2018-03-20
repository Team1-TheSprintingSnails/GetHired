using System.Collections.Generic;
using Bytes2you.Validation;
using GetHired.Core.Commands.Contracts;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;

namespace GetHired.Core.Commands
{
    public class AddJobOffer : ICommand
    {
        private readonly IUnitOfWork unitOfWork;

        public AddJobOffer(IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, "unit of work").IsNull().Throw();

            this.unitOfWork = unitOfWork;
        }

        public string Execute(IList<string> parameters)
        {
            string position = parameters[0];
            string description = parameters[1];
            decimal payment = decimal.Parse(parameters[2]);
            string companyName = parameters[3];
            string jobTypeStr = parameters[4];
            string jobCategoryStr = parameters[5];

            // need to be fixed
            var jobOffer = new JobOffer();
            this.unitOfWork.JobOfferRepository.Insert(jobOffer);

            return $"Vehicle with ID 0 was created."; // also to be fixed
        }
    }
}
