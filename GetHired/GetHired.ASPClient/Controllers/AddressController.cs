using System.Linq;
using System.Net;
using System.Web.Mvc;
using GetHired.DTO;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class AddressController : Controller
    {
        private readonly ICityService cityService;
        private readonly IAddressService addressService;

        public AddressController(ICityService cityService, IAddressService addressService)
        {
            this.cityService = cityService;
            this.addressService = addressService;
        }
        
        [ActionName("Index")]
        public ActionResult GetAddressesByCompanyId(int id)
        {
            var results = this.addressService.GetByCompanyId(id);
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

            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;

            return View(new AddressModel { CompanyId = id.Value });
        }

        // POST: Address/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddressByCompanyId(AddressModel model)
        {
            if (addressService.Add(model))
            {
                return RedirectToAction("Index", new {id = model.CompanyId});
            }
            
            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;

            return View(model);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = this.addressService.GetById(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }

            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;
            return View(address);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressModel address)
        {
            if (this.addressService.Update(address))
            {
                return RedirectToAction("Index", new {id=address.CompanyId});
            }

            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;
            return View(address);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var address = this.addressService.GetById(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var address = this.addressService.GetById(id);

            if (address == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (this.addressService.DeleteById(id))
            {
                return RedirectToAction("Index", new {id=address.CompanyId});
            }

            return View(address);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var address = this.addressService.GetByIdWithCity(id.Value);

            if (address == null)
            {
                return HttpNotFound();
            }

            return View(address);
        }
    }
}