using System.Linq;
using System.Net;
using System.Web.Mvc;
using GetHired.DTO;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class CompanyJobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        public CompanyJobOfferController(IJobOfferService jobOfferService)
        {
            this.jobOfferService = jobOfferService;
        }

        // GET: CompanyJobOffer
        public ActionResult Index(int id)
        {
            var results = this.jobOfferService.GetByCompanyId(id);
            ViewBag.CompanyId = id;

            return View(results);
        }



        // GET: JobOffer/Create
        public ActionResult Create(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobOffers = this.jobOfferService.GetAll().ToList();
            ViewBag.JobOffers = jobOffers;

            return View(new JobOfferModel() { CompanyId = id.Value });
        }

        // POST: JobOffer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOfferModel model)
        {
            if (this.jobOfferService.Add(model))
            {
                return RedirectToAction("Index", new { id = model.CompanyId });
            }

            var jobOffers = this.jobOfferService.GetAll().ToList();
            ViewBag.JobOffers = jobOffers;

            return View(model);
        }

        //public ActionResult Details(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var jobOfferWithCompany = this.jobOfferService.GetByIdWithCompany(id.Value);

        //    if (jobOfferWithCompany == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(jobOfferWithCompany);
        //}

        // GET: Company/Delete/5

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobOffer = this.jobOfferService.GetById(id.Value);

            if (jobOffer == null)
            {
                return HttpNotFound();
            }

            return View(jobOffer);
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var jobOffer = this.jobOfferService.GetById(id);

            if (jobOffer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (this.jobOfferService.DeleteById(id))
            {
                return RedirectToAction("Index", new { id = jobOffer.CompanyId });
            }

            return View(jobOffer);
        }
    }
}