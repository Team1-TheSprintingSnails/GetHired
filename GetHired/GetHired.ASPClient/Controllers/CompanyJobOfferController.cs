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



        // GET: CompanyJobOffer/Create
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

        // POST: CompanyJobOffer/Create
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

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobOfferWithCompany = this.jobOfferService.GetByIdWithCompany(id.Value);

            if (jobOfferWithCompany == null)
            {
                return View("NotFound");
            }

            return View(jobOfferWithCompany);
        }

        // GET: CompanyJobOffer/Delete/5

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

        // POST: CompanyJobOffer/Delete/5
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

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("NotFound");
            }
            var jobOffer = this.jobOfferService.GetById(id.Value);
            if (jobOffer == null)
            {
                return View("NotFound");
                //return HttpNotFound();
            }

            return View(jobOffer);
        }

        // POST: CompanyJobOffer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobOfferModel jobOffer)
        {
            if (this.jobOfferService.Update(jobOffer))
            {
                return RedirectToAction("Index", new { id = jobOffer.CompanyId });
            }
            
            return View(jobOffer);
        }
    }
}