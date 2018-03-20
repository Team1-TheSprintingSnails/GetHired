using GetHired.DataModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHired.Services.Services
{
    class JobOfferService
    {
        private IUnitOfWork unitOfWork;

        public JobOfferService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}