using System;
using NUnit.Framework;
using GetHired.Services.Services;
using Moq;
using AutoMapper;
using GetHired.DataModels.Contracts;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheFirstArgumentIsNull()
        {
            //Arrange,Act&Assert
            var mockedMapper = new Mock<IMapper>();
            Assert.Throws<ArgumentNullException>(() => new AddressService(null, mockedMapper.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheSecondArgumentIsNull()
        {
            //Arrange,Act&Assert
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            Assert.Throws<ArgumentNullException>(() => new AddressService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBothArgumentsAreNull()
        {
            //Arrange,Act&Assert
            Assert.Throws<ArgumentNullException>(() => new AddressService(null, null));
        }
    }
}