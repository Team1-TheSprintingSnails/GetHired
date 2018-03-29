using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GetHired.DataModels.Models;
using GetHired.DTO;
using GetHired.Services.Services;

namespace GetHired.ASPClient.Controllers
{
    public class AddressController : Controller
    {
        private readonly CityService cityService = new CityService(new UnitOfWork(new GetHiredContext()), Mapper.Instance);
        private readonly AddressService addressService = new AddressService(new UnitOfWork(new GetHiredContext()), Mapper.Instance);

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