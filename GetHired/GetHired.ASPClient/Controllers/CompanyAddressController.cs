using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using GetHired.ASPClient.Models;
using GetHired.DTO;
using GetHired.Services.Contracts;

namespace GetHired.ASPClient.Controllers
{
    public class CompanyAddressController : Controller
    {
        private readonly ICityService cityService;
        private readonly IAddressService addressService;
        private readonly IMapper mapper;

        public CompanyAddressController(ICityService cityService, IAddressService addressService, IMapper mapper)
        {
            this.cityService = cityService;
            this.addressService = addressService;
            this.mapper = mapper;
        }

        [ActionName("Index")]
        public ActionResult GetAddressesByCompanyId(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var companyAddressesViewModel = new CompanyAddressesViewModel
            {
                Addresses = this.addressService.GetByCompanyId(id.Value),
                CompanyId = id.Value
            };

            return View(companyAddressesViewModel);
        }

        // GET: Address/Create
        [ActionName("Create")]
        public ActionResult CreateAddressByCompanyId(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var createAddressViewModel = 

            return View(createAddressViewModel);
        }

        // POST: Address/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddressByCompanyId(AddressModel model)
        {
            if (addressService.Add(model))
            {
                return RedirectToAction("Index", new { id = model.CompanyId });
            }

            var createAddressViewModel = new AddOrUpdateAddressViewModel
            {
                Address = model,
                CitiesDropDownList = cityService.GetAll().ToList()
            };

            return View(createAddressViewModel);
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

            var updateAddressViewModel = new AddOrUpdateAddressViewModel
            {
                Address = address,
                CitiesDropDownList = cityService.GetAll().ToList()
            };

            return View(updateAddressViewModel);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressModel address)
        {
            if (this.addressService.Update(address))
            {
                return RedirectToAction("Index", new { id = address.CompanyId });
            }

            var updateAddressViewModel = new AddOrUpdateAddressViewModel
            {
                Address = address,
                CitiesDropDownList = cityService.GetAll().ToList()
            };

            return View(updateAddressViewModel);
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
                return RedirectToAction("Index", new { id = address.CompanyId });
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