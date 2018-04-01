using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyJobOfferControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnCreateView_WhenInvokedWithoutParams()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Create(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void ReturnNotFound_WhenInvokedWithNull()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            int? id = null;
            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Create(id) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnCreateView_WhenInvokedAddReturnsFalse()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.Add(jobOfferModelMock.Object)).Returns(false);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Create(jobOfferModelMock.Object) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void RedirectToIndexView_WhenCompanyIsCreated()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.Add(jobOfferModelMock.Object)).Returns(true);


            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Create(jobOfferModelMock.Object) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }
    }
}
