using AutoMapper;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Services;
using Moq;
using NUnit.Framework;
using System;

namespace GetHired.UnitTests.Services.JobOfferServiceTests
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
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(jobOfferService.DeleteById(1));
        }

        [Test]
        public void CallInheritedGetByIdMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedJobOffer.Object);
            jobOfferService.DeleteById(1);

            //Assert
            mockedJobOfferRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Test]
        public void CallInheritedDeleteMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedJobOfferModel = new Mock<JobOfferModel>();

            //Act
            mockedMapper.Setup(x => x.Map<JobOffer>(mockedJobOfferModel.Object)).Returns(mockedJobOffer.Object);
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            jobOfferService.Delete(mockedJobOfferModel.Object);

            //Assert
            mockedJobOfferRepository.Verify(x => x.Delete(mockedJobOffer.Object), Times.Once);
        }

        [Test]
        public void CallSaveChangesMethod_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedJobOfferModel = new Mock<JobOfferModel>();

            //Act
            mockedMapper.Setup(x => x.Map<JobOffer>(mockedJobOfferModel.Object)).Returns(mockedJobOffer.Object);
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            jobOfferService.Delete(mockedJobOfferModel.Object);

            //Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ExecuteMethodAndReturnTrue_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedJobOfferModel = new Mock<JobOfferModel>();

            //Act
            mockedMapper.Setup(x => x.Map<JobOffer>(mockedJobOfferModel.Object)).Returns(mockedJobOffer.Object);
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.Update(mockedJobOffer.Object));
            mockedUnitOfWork.Setup(x => x.SaveChanges());

            //Assert
            Assert.IsTrue(jobOfferService.Delete(mockedJobOfferModel.Object));
        }
    }
}