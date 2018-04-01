using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyJobOfferControllerTests
{
    [TestFixture]
    public class DeleteConfirmed_Should
    {
        [Test]
        public void ReturnNotFound_WhenNoSuchJobOffer()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            JobOfferModel jobOfferModel = null;
            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModel);
            
            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.DeleteConfirmed(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(result.ViewName, "NotFound");
        }

        [Test]
        public void RedirectToIndex_WhenJobOfferIsDeleted()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var  jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModelMock.Object);
            jobOfferServiceMock.Setup(x => x.DeleteById(It.IsAny<int>())).Returns(true);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.DeleteConfirmed(It.IsAny<int>()) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }

        [Test]
        public void ReturnDeleteView_WhenJobOfferIsDeleted()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModelMock.Object);
            jobOfferServiceMock.Setup(x => x.DeleteById(It.IsAny<int>())).Returns(false);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.DeleteConfirmed(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual(result.ViewName, "Delete");
        }
    }
}
