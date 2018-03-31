using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.CompanyControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnProperView()
        {
            var companyServiceMock = new Mock<ICompanyService>();

            var controller = new CompanyController(companyServiceMock.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
