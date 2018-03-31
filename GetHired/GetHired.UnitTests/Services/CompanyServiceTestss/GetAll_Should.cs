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

namespace GetHired.UnitTests.Services.CompanyServiceTestss
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
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            mockedCompanyRepository.Setup(x => x.All).Returns(new List<Company>() { mockedCompany.Object });

            //Assert
            var collectionOfCompanies = new List<CompanyModel>(companyService.GetAll());
            Assert.AreEqual(1, collectionOfCompanies.Count);
        }
    }
}