using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyJobOfferControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void ReturnNotFound_WhenIdHasNoValue()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Details(null) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnDetailsView_WhenInvokedWithCorrectParams()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferWithCompanyModelMock = new Mock<JobOfferWithCompanyModel>();
            jobOfferServiceMock.Setup(x => x.GetByIdWithCompany(It.IsAny<int>()))
                .Returns(jobOfferWithCompanyModelMock.Object);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
           
            var result = controller.Details(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void ReturnNotFound_WhenInvokedWithCorrectParams()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            JobOfferWithCompanyModel jobOfferWithCompanyModelMock = null;
            jobOfferServiceMock.Setup(x => x.GetByIdWithCompany(It.IsAny<int>()))
                .Returns(jobOfferWithCompanyModelMock);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.Details(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }
    }
}
