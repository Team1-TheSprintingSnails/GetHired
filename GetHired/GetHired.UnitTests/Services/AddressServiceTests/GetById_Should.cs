using System;
using NUnit.Framework;
using GetHired.DataModels.Repositories.Contracts;
using Moq;
using GetHired.DomainModels;
using GetHired.DataModels.Contracts;
using AutoMapper;
using GetHired.Services.Services;
using System.Linq.Expressions;
using GetHired.DTO;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void MakeAllChainCalls_WhenInvoked()
        {
            //Arrange
            var mockedAddressModel = new Mock<AddressModel>();
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.FirstOrDefaultWithCity(It.IsAny<Expression<Func<Address, bool>>>())).Returns(mockedAddress.Object);
            mockedMapper.Setup(x => x.Map<AddressModel>(mockedAddress.Object)).Returns(mockedAddressModel.Object);
            addressService.GetById(1);
            mockedMapper.Verify(x => x.Map<AddressModel>(mockedAddress.Object), Times.Once);
        }

        [Test]
        public void ReturnExpectedValue_WhenInvoked()
        {
            //Arrange
            var mockedAddressModel = new Mock<AddressModel>();
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.FirstOrDefaultWithCity(It.IsAny<Expression<Func<Address, bool>>>())).Returns(mockedAddress.Object);
            mockedMapper.Setup(x => x.Map<AddressModel>(mockedAddress.Object)).Returns(mockedAddressModel.Object);
            Assert.AreEqual(mockedAddressModel.Object, addressService.GetById(1));
        }
    }
}