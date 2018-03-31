using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ReturnFalse_WhenNullArgumentIsPassed()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            Assert.IsFalse(addressService.Delete(null));
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
            Assert.IsFalse(addressService.Delete(mockedAddressModel.Object));
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
            addressService.Delete(mockedAddressModel.Object);

            //Assert
            mockedMapper.Verify(x => x.Map<Address>(mockedAddressModel.Object), Times.Once);
        }

        [Test]
        public void CallInheritedDeleteMethod_WhenInvokedWithValidArgs()
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
            addressService.Delete(mockedAddressModel.Object);

            //Assert
            mockedAddressRepository.Verify(x => x.Delete(mockedAddress.Object), Times.Once);
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
            addressService.Delete(mockedAddressModel.Object);

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
            Assert.IsTrue(addressService.Delete(mockedAddressModel.Object));
        }
    }
}