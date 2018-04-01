using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.JobOfferControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnProperView_WhenInvoked()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();

            var controller = new JobOfferController(jobOfferServiceMock.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
