using System;
using GetHired.DataModels.Contracts;
using Moq;
using NUnit.Framework;
using AutoMapper;
using GetHired.Services.Services;
using GetHired.DTO;
using GetHired.DomainModels;
using GetHired.DataModels.Repositories.Contracts;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ReturnFalse_WhenNullArgumentIsPassed()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            Assert.IsFalse(addressService.Update(null));
        }

        [Test]
        public void ReturnFalse_WhenExceptionOccured()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedUnitOfWork.Setup(x => x.AddressRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(addressService.Update(mockedAddressModel.Object));
        }

        [Test]
        public void CallMapperMapMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Address>(mockedAddressModel.Object)).Returns(mockedAddress.Object);
            addressService.Update(mockedAddressModel.Object);

            //Assert
            mockedMapper.Verify(x => x.Map<Address>(mockedAddressModel.Object), Times.Once);
        }

        [Test]
        public void CallInheritedUpdateMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Address>(mockedAddressModel.Object)).Returns(mockedAddress.Object);
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            addressService.Update(mockedAddressModel.Object);

            //Assert
            mockedAddressRepository.Verify(x => x.Update(mockedAddress.Object), Times.Once);
        }

        [Test]
        public void CallSaveChangesMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Address>(mockedAddressModel.Object)).Returns(mockedAddress.Object);
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            addressService.Update(mockedAddressModel.Object);

            //Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ExecuteMethodAndReturnTrue_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Address>(mockedAddressModel.Object)).Returns(mockedAddress.Object);
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.Update(mockedAddress.Object));
            mockedUnitOfWork.Setup(x => x.SaveChanges());

            //Assert
            Assert.IsTrue(addressService.Update(mockedAddressModel.Object));
        }
    }
}