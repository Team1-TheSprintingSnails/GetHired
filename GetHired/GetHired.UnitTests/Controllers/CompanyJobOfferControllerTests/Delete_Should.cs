using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyJobOfferControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnViewNotFound_WhenIdIsNull()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.Delete(null) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnNotFound_WhenNoSuchCompanyExists()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            JobOfferModel companyModel = null;
            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModel);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);
            var result = controller.Delete(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnDeleteView_WhenCompanyExists()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();
            var jobOfferModelMock = new Mock<JobOfferModel>();
            jobOfferServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(jobOfferModelMock.Object);

            var controller = new CompanyJobOfferController(jobOfferServiceMock.Object);

            var result = controller.Delete(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}
