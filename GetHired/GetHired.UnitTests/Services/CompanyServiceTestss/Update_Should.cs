using System;
using GetHired.DataModels.Contracts;
using Moq;
using NUnit.Framework;
using AutoMapper;
using GetHired.Services.Services;
using GetHired.DTO;
using GetHired.DataModels.Repositories.Models;
using GetHired.DomainModels;
using GetHired.DataModels.Repositories.Contracts;

namespace GetHired.UnitTests.Services.CompanyServiceTestss
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
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            Assert.IsFalse(companyService.Update(null));
        }

        [Test]
        public void ReturnFalse_WhenExceptionOccured()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyModel = new Mock<CompanyModel>();

            //Act
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(companyService.Update(mockedCompanyModel.Object));
        }

        [Test]
        public void CallMapperMapMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            companyService.Update(mockedCompanyModel.Object);

            //Assert
            mockedMapper.Verify(x => x.Map<Company>(mockedCompanyModel.Object), Times.Once);
        }

        [Test]
        public void CallInheritedUpdateMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            companyService.Update(mockedCompanyModel.Object);

            //Assert
            mockedCompanyRepository.Verify(x => x.Update(mockedCompany.Object), Times.Once);
        }

        [Test]
        public void CallSaveChangesMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            companyService.Update(mockedCompanyModel.Object);

            //Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ExecuteMethodAndReturnTrue_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            mockedCompanyRepository.Setup(x => x.Update(mockedCompany.Object));
            mockedUnitOfWork.Setup(x => x.SaveChanges());

            //Assert
            Assert.IsTrue(companyService.Update(mockedCompanyModel.Object));
        }
    }
}