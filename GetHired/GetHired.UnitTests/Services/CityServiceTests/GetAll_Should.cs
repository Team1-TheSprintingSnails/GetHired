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

namespace GetHired.UnitTests.Services.CityServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAllCitiesMappedToCityModels_WhenInvoked()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var cityService = new CityService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCityRepository = new Mock<IReadonlyRepository<City>>();
            var mockedCity = new Mock<City>();

            //Act
            mockedUnitOfWork.Setup(x => x.CityRepository).Returns(mockedCityRepository.Object);
            mockedCityRepository.Setup(x => x.All).Returns(new List<City>() { mockedCity.Object });

            //Assert
            var collectionOfCities = new List<CityModel>(cityService.GetAll());
            Assert.AreEqual(1, collectionOfCities.Count);
        }
    }
}