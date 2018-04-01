using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.AddressControllerTests
{
    [TestFixture]
    public class DeleteConfirmed_Should
    {
        [Test]
        public void ReturnViewOfProperType_WhenIvokedWithId()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            var companyModelMock = new Mock<CompanyModel>();
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock.Object);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Delete(It.IsAny<int>());
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [Test]
        public void ReturnHttpStatusCodeResult_WhenCompanyIsNull()
        {
            var companyServiceMock = new Mock<ICompanyService>();
            CompanyModel companyModelMock = null;
            companyServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(companyModelMock);

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Delete(It.IsAny<int>());
            Assert.IsInstanceOf(typeof(HttpStatusCodeResult), result);
        }

        
    }
}
