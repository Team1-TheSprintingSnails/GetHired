using System;
using NUnit.Framework;
using GetHired.DataModels.Contracts;
using Moq;
using System.Linq.Expressions;
using GetHired.DomainModels;
using AutoMapper;
using GetHired.Services.Services;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DataModels.Repositories.Models;
using GetHired.DTO.ViewModels;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class GetByIdWithCity_Should
    {
        [Test]
        public void MakeAllChainCalls_WhenInvoked()
        {
            //Arrange
            var mockedAddressWithCityViewModel = new Mock<AddressWithCityModel>();
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.FirstOrDefaultWithCity(It.IsAny<Expression<Func<Address, bool>>>())).Returns(mockedAddress.Object);
            mockedMapper.Setup(x => x.Map<AddressWithCityModel>(mockedAddress)).Returns(mockedAddressWithCityViewModel.Object);
            addressService.GetByIdWithCity(1);
            mockedMapper.Verify(x => x.Map<AddressWithCityModel>(mockedAddress.Object), Times.Once);
        }

        [Test]
        public void ReturnExpectedValue_WhenInvoked()
        {
            //Arrange
            var mockedAddressWithCityViewModel = new Mock<AddressWithCityModel>();
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.FirstOrDefaultWithCity(It.IsAny<Expression<Func<Address, bool>>>())).Returns(mockedAddress.Object);
            mockedMapper.Setup(x => x.Map<AddressWithCityModel>(mockedAddress.Object)).Returns(mockedAddressWithCityViewModel.Object);
            Assert.AreEqual(mockedAddressWithCityViewModel.Object, addressService.GetByIdWithCity(1));
        }
    }
}