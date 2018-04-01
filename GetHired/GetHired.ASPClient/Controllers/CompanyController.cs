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
            return View("Index", companies);
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return View("NotFound");
            }

            return View("Details", company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyModel company)
        {
            if (this.companyService.Add(company))
            {
                return RedirectToAction("Index");
            }

            return View("Create", company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return View("NotFound");
            }

            return View("Edit", company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyModel company)
        {
            if (this.companyService.Update(company))
            {
                return RedirectToAction("Index");
            }

            return View("Edit", company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFound");
            }
            var company = this.companyService.GetById(id.Value);
            if (company == null)
            {
                return View("NotFound");
            }

            return View("Delete", company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = this.companyService.GetById(id);
            if (company == null)
            {
                return View("NotFound");
            }

            if (this.companyService.Delete(company))
            {
                return RedirectToAction("Index");
            }

            return View("Delete", company);
        }
    }
}
