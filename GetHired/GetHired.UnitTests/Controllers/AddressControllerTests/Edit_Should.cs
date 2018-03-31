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
        public void ReturnProperView_WhenIvokedWithId()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressModelMock = new Mock<AddressModel>();
            addressServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(addressModelMock.Object);

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void ReturnIndexView_WhenUpdateReturnsTrue()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressModelMock = new Mock<AddressModel>();
            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            addressServiceMock.Setup(x => x.Update(addressModelMock.Object)).Returns(true);

            var result = controller.Edit(addressModelMock.Object) as RedirectToRouteResult;

            Assert.AreEqual(result.RouteValues["Action"], "Index");
        }

        [Test]
        public void ReturnEditView_WhenUpdateReturnsFalse()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressModelMock = new Mock<AddressModel>();
            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            addressServiceMock.Setup(x => x.Update(addressModelMock.Object)).Returns(false);

            var result = controller.Edit(addressModelMock.Object) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);

        }

        [Test]
        public void ReturnViewResult_WhenAddressIsNull()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressWithCityMock = new Mock<AddressWithCityModel>();
            addressServiceMock.Setup(x => x.GetByIdWithCity(It.IsAny<int>())).Returns(addressWithCityMock.Object);

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.Edit(1);
            Assert.IsInstanceOf(typeof(HttpNotFoundResult), result);
        }
    }
}
