using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.AddressControllerTests
{
    [TestFixture()]
    public class Edit_Should
    {
        [Test]
        public void ReturnEditView_WhenIvokedWithId()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Edit(It.IsAny<int>()) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void ReturnIndexView_WhenUpdateReturnsTrue()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.Update(companyModelMock.Object)).Returns(true);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Edit(companyModelMock.Object) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }

        [Test]
        public void ReturnEditView_WhenUpdateReturnsFalse()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.Update(companyModelMock.Object)).Returns(false);
            
            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Edit(companyModelMock.Object) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}
