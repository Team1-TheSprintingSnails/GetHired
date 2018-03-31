using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.AddressControllerTests
{
    [TestFixture]
    public class CreateAddressByCompanyId_Should
    {
        [Test]
        public void ReturnProperView_WhenIvokedWithId()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.CreateAddressByCompanyId(1) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void ReturnProperView_WhenIvokedWithAddressModel()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressModelMock = new Mock<AddressModel>();

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.CreateAddressByCompanyId(addressModelMock.Object) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
