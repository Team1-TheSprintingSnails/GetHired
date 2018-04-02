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

namespace GetHired.UnitTests.Services.JobOfferServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAllJobOffersMappedToJobOfferModels_WhenInvoked()
        {
            //Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapper>();
            var jobOfferService = new JobOfferService(mockedUnitOfWork.Object, mockedMapper.Object);
            var mockedJobOfferRepository = new Mock<IJobOfferRepository>();
            var mockedJobOffer = new Mock<JobOffer>();

            //Act
            mockedUnitOfWork.Setup(x => x.JobOfferRepository).Returns(mockedJobOfferRepository.Object);
            mockedJobOfferRepository.Setup(x => x.GetAllOrderedByRating()).Returns(new List<JobOffer>() { mockedJobOffer.Object });

            //Assert
            var collectionOfJobOffers = new List<JobOfferModel>(jobOfferService.GetAll());
            Assert.AreEqual(1, collectionOfJobOffers.Count);
        }
    }
}