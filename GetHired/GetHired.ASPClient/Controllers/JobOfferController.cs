using System.Web.Mvc;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            this.jobOfferService = jobOfferService;
        }

        // GET: JobOffer 
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View(jobOffers);
        }

        public ActionResult DownloadPDF()
        {
            return View();
        }
    }
}