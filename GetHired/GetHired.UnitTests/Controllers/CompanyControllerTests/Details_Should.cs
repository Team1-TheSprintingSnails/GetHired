using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void ReturnNotFound_WhenIdHasNoValue()
        {
            var companyServiceMock = new Mock<ICompanyService>();

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Details(null) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnHttpNotFoundResult_WhenIdHasNoValue()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Details(It.IsAny<int>());
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void ReturnDetailsView_WhenInvokedWithCorrectParams()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);
            
            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Details(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
    }
}
