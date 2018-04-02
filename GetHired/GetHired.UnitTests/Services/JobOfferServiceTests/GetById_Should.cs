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

namespace GetHired.UnitTests.Services.JobOfferServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void MakeAllChainCalls_WhenInvoked()
        {
            //Arrange
            var mockedJobOfferModel = new Mock<JobOfferModel>();
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedJobOffer.Object);
            mockedMapper.Setup(x => x.Map<JobOfferModel>(mockedJobOffer.Object)).Returns(mockedJobOfferModel.Object);
            jobOfferService.GetById(1);
            mockedMapper.Verify(x => x.Map<JobOfferModel>(mockedJobOffer.Object), Times.Once);
        }

        [Test]
        public void ReturnExpectedValue_WhenInvoked()
        {
            //Arrange
            var mockedJobOfferModel = new Mock<JobOfferModel>();
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);

            //Act & Assert
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedJobOffer.Object);
            mockedMapper.Setup(x => x.Map<JobOfferModel>(mockedJobOffer.Object)).Returns(mockedJobOfferModel.Object);
            Assert.AreEqual(mockedJobOfferModel.Object, jobOfferService.GetById(1));
        }
    }
}