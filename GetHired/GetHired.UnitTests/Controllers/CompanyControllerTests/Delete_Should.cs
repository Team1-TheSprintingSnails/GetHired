using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnViewNotFound_WhenIdIsNull()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var controller = new CompanyController(companyServiceMock.Object);

            var result = controller.Delete(null) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void ReturnHttpNotFound_WhenNoSuchCompanyExists()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            CompanyModel companyModel = null;
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModel);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Delete(It.IsAny<int>());
            Assert.IsInstanceOf(typeof(HttpNotFoundResult), result);
        }

        [Test]
        public void ReturnDeleteView_WhenCompanyExists()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);

            var controller = new CompanyController(companyServiceMock.Object);

            var result = controller.Delete(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}
