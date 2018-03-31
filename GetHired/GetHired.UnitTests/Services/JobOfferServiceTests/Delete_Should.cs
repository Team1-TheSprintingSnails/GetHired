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
    public class Delete_Should
    {
        [Test]
        public void ReturnFalse_WhenNullArgumentIsPassed()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            Assert.IsFalse(jobOfferService.Delete(null));
        }

        [Test]
        public void ReturnFalse_WhenExceptionOccured()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferModel = new Mock<JobOfferModel>();

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Throws(new Exception());

            //Assert
            Assert.IsFalse(jobOfferService.Delete(mockedJobOfferModel.Object));
        }

        [Test]
        public void CallMapperMapMethod_WhenInvokedWithValidArgs()
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
            jobOfferService.Delete(mockedJobOfferModel.Object);

            //Assert
            mockedMapper.Verify(x => x.Map<JobOffer>(mockedJobOfferModel.Object), Times.Once);
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