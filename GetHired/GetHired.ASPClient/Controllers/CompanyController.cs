using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = companyService.GetAll();
            return View(companies);
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = this.companyService.GetById(id.Value);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    if (addressService.Add(model))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Invalid = "Company already exists.";
        //    return View(model);
        //}

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var company = companyService.GetById(id);
                if (company == null)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
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
