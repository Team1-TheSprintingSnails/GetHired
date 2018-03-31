using System.Web.Mvc;
using GetHired.Services.Contracts;
using GetHired.Utils.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        private readonly IFileWriter fileWriter;

        public JobOfferController(IJobOfferService jobOfferService, IFileWriter fileWriter)
        {
            this.jobOfferService = jobOfferService;
            this.fileWriter = fileWriter;
        }

        // GET: JobOffer 
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View(jobOffers);
        }

        public ActionResult DownloadPDF()
        {
            this.fileWriter.WriteFile();
            return View();
        }
    }
}