using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace GetHired.UnitTests.Services.CompanyServiceTestss
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
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(companyService.DeleteById(1));
        }

        [Test]
        public void CallInheritedGetByIdMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var companyService = new CompanyService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedCompany = new Mock<Company>();
            var mockedCompanyRepository = new Mock<IGenericRepository<Company>>();

            //Act
            mockedUnitOfWork.Setup(x => x.CompanyRepository).Returns(mockedCompanyRepository.Object);
            mockedCompanyRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedCompany.Object);
            companyService.DeleteById(1);

            //Assert
            mockedCompanyRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Test]
        public void CallInheritedDeleteMethod_WhenInvokedWithValidArgs()
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
            companyService.Delete(mockedCompanyModel.Object);

            //Assert
            mockedCompanyRepository.Verify(x => x.Delete(mockedCompany.Object), Times.Once);
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
            companyService.Delete(mockedCompanyModel.Object);

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
            Assert.IsTrue(companyService.Delete(mockedCompanyModel.Object));
        }
    }
}