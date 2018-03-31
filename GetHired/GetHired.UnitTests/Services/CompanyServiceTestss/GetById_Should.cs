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

namespace GetHired.UnitTests.Services.CompanyServiceTestss
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void MakeAllChainCalls_WhenInvoked()
        {
            //Arrange
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompany = new Mock<Company>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            mockedCompanyRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedCompany.Object);
            mockedMapper.Setup(x => x.Map<CompanyModel>(mockedCompany.Object)).Returns(mockedCompanyModel.Object);
            companyService.GetById(1);
            mockedMapper.Verify(x => x.Map<CompanyModel>(mockedCompany.Object), Times.Once);
        }

        [Test]
        public void ReturnExpectedValue_WhenInvoked()
        {
            //Arrange
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompany = new Mock<Company>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            mockedCompanyRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedCompany.Object);
            mockedMapper.Setup(x => x.Map<CompanyModel>(mockedCompany.Object)).Returns(mockedCompanyModel.Object);
            Assert.AreEqual(mockedCompanyModel.Object, companyService.GetById(1));
        }
    }
}