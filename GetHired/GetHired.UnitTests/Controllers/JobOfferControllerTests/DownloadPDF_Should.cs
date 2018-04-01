using GetHired.ASPClient.Controllers;
using GetHired.Services.Contracts;
using Moq;
using NUnit.Framework;
using Rotativa;

namespace GetHired.UnitTests.Controllers.JobOfferControllerTests
{
    [TestFixture]
    public class DownloadPDF_Should
    {
        [Test]
        public void ReturnActionAsPdf_WhenInvoked()
        {
            var jobOfferServiceMock = new Mock<IJobOfferService>();

            var controller = new JobOfferController(jobOfferServiceMock.Object);
            var result = controller.DownloadPDF();
            Assert.IsInstanceOf(typeof(ActionAsPdf), result);
        }
    }
}
