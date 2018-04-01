using System.Linq;
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

            return View("Index", results);
        }

        // GET: CompanyJobOffer/Create
        public ActionResult Create(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }

            var jobOffers = this.jobOfferService.GetAll().ToList();
            ViewBag.JobOffers = jobOffers;

            return View("Create", new JobOfferModel() { CompanyId = id.Value });
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

            return View("Create", model);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }

            var jobOfferWithCompany = this.jobOfferService.GetByIdWithCompany(id.Value);

            if (jobOfferWithCompany == null)
            {
                return View("NotFound");
            }

            return View("Details", jobOfferWithCompany);
        }

        // GET: CompanyJobOffer/Delete/5

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }
            var jobOffer = this.jobOfferService.GetById(id.Value);

            if (jobOffer == null)
            {
                return View("NotFound");
            }

            return View("Delete", jobOffer);
        }

        // POST: CompanyJobOffer/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var jobOffer = this.jobOfferService.GetById(id);

            if (jobOffer == null)
            {
                return View("NotFound");
            }

            if (this.jobOfferService.DeleteById(id))
            {
                return RedirectToAction("Index", new { id = jobOffer.CompanyId });
            }

            return View("Delete", jobOffer);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }
            var jobOffer = this.jobOfferService.GetById(id.Value);

            if (jobOffer == null)
            {
                return View("NotFound");
            }

            return View("Edit", jobOffer);
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

            return View("Edit", jobOffer);
        }
    }
}