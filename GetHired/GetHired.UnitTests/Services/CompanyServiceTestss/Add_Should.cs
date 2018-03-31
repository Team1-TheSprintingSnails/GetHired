using System;
using NUnit.Framework;
using GetHired.DataModels.Contracts;
using Moq;
using AutoMapper;
using GetHired.Services.Services;
using GetHired.DTO;
using GetHired.DomainModels;
using GetHired.DataModels.Repositories.Contracts;

namespace GetHired.UnitTests.Services.CompanyServiceTestss
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ReturnFalse_WhenNullArgumentIsPassed()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            Assert.IsFalse(companyService.Add(null));
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
            Assert.IsFalse(companyService.Add(mockedCompanyModel.Object));
        }

        [Test]
        public void CallMapperMapMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            companyService.Add(mockedCompanyModel.Object);

            //Assert
            mockedMapper.Verify(x => x.Map<Company>(mockedCompanyModel.Object), Times.Once);
        }

        [Test]
        public void CallInheritedInsertMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            companyService.Add(mockedCompanyModel.Object);

            //Assert
            mockedCompanyRepository.Verify(x => x.Insert(mockedCompany.Object), Times.Once);
        }

        [Test]
        public void CallSaveChangesMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();
            var mockedCompany = new Mock<Company>();
            var mockedCompanyModel = new Mock<CompanyModel>();

            //Act
            mockedMapper.Setup(x => x.Map<Company>(mockedCompanyModel.Object)).Returns(mockedCompany.Object);
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            companyService.Add(mockedCompanyModel.Object);

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
            Assert.IsTrue(companyService.Add(mockedCompanyModel.Object));
        }
    }
}