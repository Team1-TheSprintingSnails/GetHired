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
            var model = new AddressModel {CompanyId = id.Value};

            return View(model);
        }

        // POST: Address/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddressByCompanyId(AddressModel model)
        {
            if (addressService.Add(model))
            {
                return RedirectToAction("Index");
            }
            
            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;

            return View(model);
        }
    }
}