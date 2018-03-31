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
    public class DeleteById_Should
    {
        [Test]
        public void ReturnFalse_WhenExceptionOccuresByMethodExecution()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            mockedUnitOfWork.Setup(x => x.AddressRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(addressService.DeleteById(1));
        }

        [Test]
        public void CallInheritedGetByIdMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();

            //Act
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedAddress.Object);
            addressService.DeleteById(1);

            //Assert
            mockedAddressRepository.Verify(x => x.GetById(1), Times.Once);
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