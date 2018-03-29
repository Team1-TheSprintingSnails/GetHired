using System.Linq;
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

        public ActionResult Index(int? id)
        {
            var results = this.addressService.GetByCompanyId(id);
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
        public ActionResult Create(AddressModel model)
        {
            model.CompanyId = 1;

            if (addressService.Add(model))
            {
                return RedirectToAction("Index");
            }
            
            var cities = cityService.GetAll().ToList();
            ViewBag.Cities = cities;
            ViewBag.Invalid = "Address already exists.";

            return View(model);
        }
    }
}