using System;
using GetHired.Services.Services;
using GetHired.DataModels.Contracts;
using Moq;
using NUnit.Framework;
using AutoMapper;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class AddressServiceConstructor_Should
    {
        [Test]
        public void ThrowNullArgumentException_WhenTheFirstArgumentIsNull()
        {
            //Arrange,Act And Assert
            var mock = new Mock<IMapper>();
            var ex = Assert.Throws<ArgumentNullException>(() => new AddressService(null, mock.Object));
        }

        [Test]
        public void ThrowNullArgumentException_WhenTheSecondArgumentIsNull()
        {
            //Arrange,Act And Assert
            var mock = new Mock<IUnitOfWork>();
            var ex = Assert.Throws<ArgumentNullException>(() => new AddressService(mock.Object, null));
        }

        [Test]
        public void ThrowNullArgumentException_WhenBothArgumentsAreNull()
        {
            //Arrange,Act And Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new AddressService(null, null));
        }
    }
}