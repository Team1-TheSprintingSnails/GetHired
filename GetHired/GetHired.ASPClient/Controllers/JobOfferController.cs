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

        // GET: Company
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View(jobOffers);
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
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

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOfferModel company)
        {
            if (this.jobOfferService.Add(company))
            {
                return RedirectToAction("Index");
            }

            return View(company);
        }

        //[ActionName("Index")]
        //public ActionResult GetJobOffersByCompanyId(int id)
        //{
        //    var results = this.jobOfferService.GetByCompanyId(id);
        //    ViewBag.CompanyId = id;

        //    return View(results);
        //}

        //// GET: Address/Create
        //[ActionName("Create")]
        //public ActionResult CreateJobOfferByCompanyId(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var cities = jobOfferService.GetAll().ToList();
        //    ViewBag.Cities = cities;

        //    return View(new JobOfferModel() { CompanyId = id.Value });
        //}

        //// POST: Address/Create
        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateJobOfferByCompanyId(JobOfferModel model)
        //{
        //    if (this.jobOfferService.Add(model))
        //    {
        //        return RedirectToAction("Index", new { id = model.CompanyId });
        //    }

        //    return View(model);
        //}

        //// GET: Company/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var jobOffer = this.jobOfferService.GetById(id.Value);
        //    if (jobOffer == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(jobOffer);
        //}

        //// GET: Company/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var jobOffer = this.jobOfferService.GetById(id.Value);
        //    if (jobOffer == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(jobOffer);
        //}

        //// POST: Company/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(JobOfferModel jobOffer)
        //{
        //    if (this.jobOfferService.Update(jobOffer))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(jobOffer);
        //}

        //// GET: Company/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var jobOffer = this.jobOfferService.GetById(id.Value);
        //    if (jobOffer == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(jobOffer);
        //}

        //// POST: Company/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var jobOffer = this.jobOfferService.GetById(id);
        //    if (jobOffer == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    if (this.jobOfferService.Delete(jobOffer))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(jobOffer);
        //}

    }
}