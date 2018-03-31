using System.Collections.Generic;
using System.Web.Mvc;
using GetHired.Services.Contracts;
using GetHired.Utils;
using GetHired.Utils.Contracts;
using Rotativa;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        private readonly IFileWriter pdfWriter;

        public JobOfferController(IJobOfferService jobOfferService, IFileWriter pdfWriter)
        {
            this.jobOfferService = jobOfferService;
            this.pdfWriter = pdfWriter;
        }

        // GET: JobOffer 
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View(jobOffers);
        }

        public ActionResult DownloadPDF()
        {
            return new ActionAsPdf("Index");
            //return View();
        }
    }
}