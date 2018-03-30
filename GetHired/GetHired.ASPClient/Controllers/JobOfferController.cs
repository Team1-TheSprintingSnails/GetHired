using System.Linq;
using System.Net;
using System.Web.Mvc;
using GetHired.DTO;
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

        [ActionName("JobOffersWithCompany")]
        public ActionResult GetAddressesByCompanyId(int id)
        {
            var results = this.jobOfferService.GetByCompanyId(id);
            ViewBag.CompanyId = id;

            return View(results);
        }

        // GET: Address/Create
        [ActionName("Create")]
        public ActionResult CreateAddressByCompanyId(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobOffers = this.jobOfferService.GetAll().ToList();
            ViewBag.JobOffers = jobOffers;

            return View(new JobOfferModel() { CompanyId = id.Value });
        }

        // POST: Address/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddressByCompanyId(JobOfferModel model)
        {
            if (this.jobOfferService.Add(model))
            {
                return RedirectToAction("Index", new { id = model.CompanyId });
            }

            var jobOffers = this.jobOfferService.GetAll().ToList();
            ViewBag.JobOffers = jobOffers;

            return View(model);
        }
    }
}