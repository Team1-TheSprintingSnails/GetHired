using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GetHired.DataModels.Models;
using GetHired.DTO;
using GetHired.Services.Contracts;
using GetHired.Services.Services;

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

        public ActionResult Index()
        {
            var results = this.addressService.GetByCompanyId(1);
            return View(results);
        }

        // GET: Address
        public ActionResult Create()
        {

            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressModel withCityViewModel)
        {
            if (ModelState.IsValid)
            {
                //withCityDetailsModel.CityId = 1;
                withCityViewModel.CompanyId = 1;

                if (addressService.Add(withCityViewModel))
                {
                    return RedirectToAction("Index");
                }
            }

            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;
            ViewBag.Invalid = "Address already exists.";
            return View(withCityViewModel);

        }
    }
}