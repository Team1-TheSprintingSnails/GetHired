using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyJobOfferControllerTests
{
    [TestFixture]
    public class Edit_Should
    {
        [Test]
        public void RedirectToIndex_WhenIvokedWithCorrectJobOfferModel()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.Update(jobOfferModelMock.Object)).Returns(true);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Edit(jobOfferModelMock.Object) as RedirectToRouteResult;
            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }

        [Test]
        public void ReturnEditView_WhenUpdateReturnsFalse()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.Update(jobOfferModelMock.Object)).Returns(false);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Edit(jobOfferModelMock.Object) as ViewResult;

            Assert.AreEqual(result.ViewName, "Edit");
        }

        [Test]
        public void ReturnNotFound_WhenIdIsNull()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            int? id = null;
            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.Edit(id) as ViewResult;

            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnNotFound_WhenNoSuchJobOffer()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            JobOfferModel jobOfferModel = null;

            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModel);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Edit(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(result.ViewName, "NotFound");
        }

        [Test]
        public void ReturnEditView_WhenInvokedWithCorrectParams()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();

            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModelMock.Object);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Edit(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(result.ViewName, "Edit");
        }
    }
}
