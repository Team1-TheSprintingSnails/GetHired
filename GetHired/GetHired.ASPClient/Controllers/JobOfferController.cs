using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GetHired.DTO;
using GetHired.Services.Services;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly JobOfferService jobOfferService;

        public JobOfferController(JobOfferService jobOfferService)
        {
            this.jobOfferService = jobOfferService;
        }
        // GET: JobOffer
        public ActionResult Index()
        {
            var jobOfferModels = this.jobOfferService.GetAll();
            return View(jobOfferModels);
        }

        // GET: JobOffer/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobOfferWithCompanyViewModel = this.jobOfferService.GetByIdWithCompany(id.Value);

            if (jobOfferWithCompanyViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(jobOfferWithCompanyViewModel);
        }

        // GET: JobOffer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobOffer/Create
        [HttpPost]
        public ActionResult Create(JobOfferModel jobOfferModel)
        {
            if (this.jobOfferService.Add(jobOfferModel))
            {
                RedirectToAction("Index");
            }

            return View(jobOfferModel);
        }

        // GET: JobOffer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobOffer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobOffer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
