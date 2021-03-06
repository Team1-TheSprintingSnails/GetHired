﻿using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.DTO;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.AddressControllerTests
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void ReturnProperView_WhenIvokedWithId()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressWithCityMock = new Mock<AddressWithCityModel>();
            addressServiceMock.Setup(x => x.GetByIdWithCity(It.IsAny<int>())).Returns(addressWithCityMock.Object);

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [Test]
        public void ReturnNotFound_WhenIdHasNoValue()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressWithCityMock = new Mock<AddressWithCityModel>();
            addressServiceMock.Setup(x => x.GetByIdWithCity(It.IsAny<int>())).Returns(addressWithCityMock.Object);

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.Details(null) as ViewResult;
            Assert.AreEqual("NotFound", result.ViewName);

        }

        [Test]
        public void ReturnViewResult_WhenAddressIsNull()
        {
            var cityServiceMock = new Mock<ICityService>();
            var addressServiceMock = new Mock<IAddressService>();
            var addressWithCityMock = new Mock<AddressWithCityModel>();
            addressServiceMock.Setup(x => x.GetByIdWithCity(It.IsAny<int>())).Returns(addressWithCityMock.Object);

            var controller = new AddressController(cityServiceMock.Object, addressServiceMock.Object);
            var result = controller.Details(It.IsAny<int>());
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }
    }
}
