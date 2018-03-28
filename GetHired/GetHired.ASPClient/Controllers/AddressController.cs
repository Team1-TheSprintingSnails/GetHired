using System.Web.Mvc;
using AutoMapper;
using GetHired.ASPClient.Models;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Models;
using GetHired.DTO;
using GetHired.Services.Services;

namespace GetHired.ASPClient.Controllers
{
    public class AddressController : Controller
    {
        private readonly CityService cityService = new CityService(new UnitOfWork(new GetHiredContext()), Mapper.Instance );
        private readonly AddressService addressService = new AddressService(new UnitOfWork(new GetHiredContext()), Mapper.Instance );

        public ActionResult Index()
        {
            return View();
        }

        // GET: Address
        public ActionResult Create()
        {
            var cities = cityService.GetAll();
            ViewBag.CityId = new SelectList(cities, "CityId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId, Name")] AddressModel model)
        {
            if (addressService.Add(model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}