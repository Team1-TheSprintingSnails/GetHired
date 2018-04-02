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

namespace GetHired.UnitTests.Services.JobOfferServiceTests
{
    [TestFixture]
    public class GetCompanyById_Should
    {
        [Test]
        public void CallInheritedFromGenericRepositoryGetByCompanyIdMethodIsCalled_WhenInvokedWithValidArgs()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            jobOfferService.GetByCompanyId(1);
            mockedJobOfferRepository.Verify(x => x.GetByCompanyId(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ReturnCollectionWithAllJobOffersMappedToJobOfferModels_WhenInvoked()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();
            var mockedJobOfferModel = new Mock<JobOfferModel>();

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.GetByCompanyId(It.IsAny<int>())).Returns(new List<JobOffer>() { mockedJobOffer.Object });

            //Assert
            var collectionOfJobOfferModels = new List<JobOfferModel>(jobOfferService.GetByCompanyId(1));
            Assert.AreEqual(1, collectionOfJobOfferModels.Count);
        }
    }
}