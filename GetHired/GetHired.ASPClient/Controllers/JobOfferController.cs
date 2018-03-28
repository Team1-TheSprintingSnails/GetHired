using System.Web.Mvc;
using AutoMapper;
using GetHired.DataModels.Models;
using GetHired.Services.Services;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly CityService cityService = new CityService(new UnitOfWork(new GetHiredContext()), Mapper.Instance);
        private readonly JobOfferService addressService = new JobOfferService(new UnitOfWork(new GetHiredContext()), Mapper.Instance);

        // GET: JobOffer
        public ActionResult Index()
        {
            return View();
        }
    }
}