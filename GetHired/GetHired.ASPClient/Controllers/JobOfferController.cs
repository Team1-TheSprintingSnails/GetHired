using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GetHired.DomainModels;
using GetHired.Services.Contracts;
using Newtonsoft.Json;
using Rotativa;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            this.jobOfferService = jobOfferService;
        }

        // GET: JobOffer 
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View(jobOffers);
        }

        public ActionResult DownloadPDF()
        {
            return new ActionAsPdf("Index");
        }

        [HttpPost]
        public ActionResult LoadFromJson(HttpPostedFileBase jsonFile)
        {
            if (!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            {

            }
            else
            {
                jsonFile.SaveAs(Server.MapPath("~/JSONFiles" + Path.GetFileName(jsonFile.FileName)));

                StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles" + Path.GetFileName(jsonFile.FileName)));

                string data = streamReader.ReadToEnd();

                var jobOffers = JsonConvert.DeserializeObject<List<JobOffer>>(data);

                jobOffers.ForEach(jo =>
                {
                    var jobOffer = new JobOffer()
                    {
                        Id = jo.Id,
                        Position = jo.Position,
                        Description = jo.Description,
                        Payment = jo.Payment,
                        CompanyId = jo.CompanyId,
                        Rating = jo.Rating,
                        JobType = jo.JobType,
                        JobCategory = jo.JobCategory,
                        Company = jo.Company,
                        LikedBy = jo.LikedBy,
                        DateModified = jo.DateModified,
                        DateCreated = jo.DateCreated
                    };
                });
            }

            return View("Index");
        }
    }
}