using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.AddressControllerTests
{
    [TestFixture]
    public class GetAddressesByCompanyId_Should
    {
        [Test]
        public void ReturnProperView()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.GetAddressesByCompanyId(1) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
