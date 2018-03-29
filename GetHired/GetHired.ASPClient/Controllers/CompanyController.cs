using System.Linq;
using System.Net;
using System.Web.Mvc;
using GetHired.DTO;
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
            var cities = companyService.GetAll().ToList();
            ViewBag.Cities = cities;

            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel model)
        {
            if (companyService.Add(model))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Invalid = "Company already exists.";
            return View(model);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = this.companyService.GetById(id.Value);

            this.companyService.Update(company);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        //// POST: Company/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        var company = companyService.GetById(id);
        //        if (company == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {

            if (this.companyService.DeleteById(id))
            {
                return View();
            }
            
            return Redirect("Index");
        }

        // POST: Company/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        if (companyService.DeleteById(id))
        //        {
        //            return RedirectToAction("Index");
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
