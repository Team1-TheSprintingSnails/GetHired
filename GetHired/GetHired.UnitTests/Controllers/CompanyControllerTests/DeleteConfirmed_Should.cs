using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyControllerTests
{
    [TestFixture]
    public class DeleteConfirmed_Should
    {
        [Test]
        public void ReturnNotFoundView_WhenCompanyIsNull()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            CompanyModel companyModel = null;

            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModel);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.DeleteConfirmed(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual("NotFound", result.ViewName);
        }

        [Test]
        public void RedirectToIndexView_WhenCompanyIsDeleted()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);
            companyServiceMock.Setup(x => x.Delete(companyModelMock.Object)).Returns(true);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.DeleteConfirmed(It.IsAny<int>()) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }

        [Test]
        public void ReturnDeleteView_WhenInvokedWithCorrectParams()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);
            companyServiceMock.Setup(x => x.Delete(companyModelMock.Object)).Returns(false);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.DeleteConfirmed(It.IsAny<int>()) as ViewResult;

            Assert.AreEqual("Delete", result.ViewName);
        }
    }
}
