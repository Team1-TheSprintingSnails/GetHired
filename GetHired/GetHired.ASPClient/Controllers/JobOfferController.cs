using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GetHired.DataModels.Contracts;
using GetHired.DomainModels;
using GetHired.Services.Contracts;
using Rotativa;

namespace GetHired.ASPClient.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferService jobOfferService;
        //private readonly IGetHiredContext ctx;

        public JobOfferController(IJobOfferService jobOfferService)//, IGetHiredContext ctx)
        {
            this.jobOfferService = jobOfferService;
            //this.ctx = ctx;
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

        // working on json loader

        //[HttpPost]
        //public ActionResult LoadFromJson(HttpPostedFileBase jsonFile)
        //{
        //    jsonFile.SaveAs(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));

        //    StreamReader streamReader = new StreamReader(Server.MapPath("~/JSONFiles/" + Path.GetFileName(jsonFile.FileName)));

        //    string data = streamReader.ReadToEnd();

        //    var jobOffers = JsonConvert.DeserializeObject<List<JobOffer>>(data);

        //    jobOffers.ForEach(jo =>
        //    {
        //        var jobOffer = new JobOffer()
        //        {
        //            Id = jo.Id,
        //            Position = jo.Position,
        //            Description = jo.Description,
        //            Payment = jo.Payment,
        //            CompanyId = jo.CompanyId,
        //            DateModified = jo.DateModified,
        //            DateCreated = jo.DateCreated,
        //            Rating = jo.Rating,
        //            JobType = jo.JobType,
        //            JobCategory = jo.JobCategory
        //        };

        //        ctx.JobOffers.Add(jobOffer);
        //        ctx.SaveChanges();
        //    });


        //    return View("Index");
        //}
    }
}