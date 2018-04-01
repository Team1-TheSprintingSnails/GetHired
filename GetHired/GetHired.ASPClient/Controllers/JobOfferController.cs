using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Newtonsoft.Json;
using Rotativa;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        private readonly IMapper mapper = Mapper.Instance;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            this.jobOfferService = jobOfferService;
        }

        // GET: JobOffer 
        public ActionResult Index()
        {
            var jobOffers = this.jobOfferService.GetAll();
            return View("Index", jobOffers);
        }

        public ActionResult DownloadPDF()
        {
            return new ActionAsPdf("Index");
        }

        [HttpPost]
        public ActionResult LoadFromJson(HttpPostedFileBase jsonFile)
        {
            jsonFile = Request.Files["jsonFile"];
            var count = Request.Files.Count;


            jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));

            using (StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName))))
            {
                string data = streamReader.ReadToEnd();

                var jobOfferModels = JsonConvert.DeserializeObject<List<JobOfferModel>>(data);
                var jobOffers = this.mapper.Map<List<JobOffer>>(jobOfferModels);

                jobOffers.ForEach(jo =>
                {
                    var jobOffer = new JobOfferModel()
                    {
                        JobOfferId = jo.Id,
                        Position = jo.Position,
                        Description = jo.Description,
                        Payment = jo.Payment,
                        CompanyId = jo.CompanyId,
                        JobOfferRating = jo.Rating,
                        JobType = jo.JobType,
                        JobCategory = jo.JobCategory
                    };

                    this.jobOfferService.Add(jobOffer);
                });
            }

            if (Session["type"] != null && Session["resulttype"] != null)
            {
                return View("Index");
            }

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}