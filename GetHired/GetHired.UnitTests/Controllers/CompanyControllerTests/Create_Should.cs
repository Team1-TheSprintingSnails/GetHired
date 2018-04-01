using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyControllerTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnCreateView_WhenInvokedWithoutParams()
        {
            var companyServiceMock = new Mock<ICompanyService>();

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void ReturnCreateView_WhenInvokedAddReturnsFalse()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.Add(companyModelMock.Object)).Returns(false);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Create(companyModelMock.Object) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void RedirectToIndexView_WhenCompanyIsCreated()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.Add(companyModelMock.Object)).Returns(true);

          
            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Create(companyModelMock.Object) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }
    }
}
