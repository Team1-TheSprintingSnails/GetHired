using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GetHired.UnitTests.Services.AddressServiceTests
{
    [TestFixture]
    public class GetCompanyById_Should
    {
        [Test]
        public void CallInheritedFromGenericRepositorySearchForMethodIsCalled_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();

            //Act
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            addressService.GetByCompanyId(1);
            mockedAddressRepository.Verify(x => x.SearchFor(It.IsAny<Expression<Func<Address, bool>>>()), Times.Once);
        }

        [Test]
        public void ReturnCollectionWithAllAddressesMappedToAddressModels_WhenInvoked()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var addressService = new AddressService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedAddressRepository = new Mock<IAddressRepository>();
            var mockedAddress = new Mock<Address>();
            var mockedAddressModel = new Mock<AddressModel>();

            //Act
            mockedUnitOfWork.Setup(x => x.AddressRepository).Returns(mockedAddressRepository.Object);
            mockedAddressRepository.Setup(x => x.SearchFor(It.IsAny<Expression<Func<Address, bool>>>())).Returns(new List<Address>() { mockedAddress.Object });

            //Assert
            var collectionOfAddressModels = new List<AddressModel>(addressService.GetByCompanyId(1));
            Assert.AreEqual(1, collectionOfAddressModels.Count);
        }
    }
}