using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class About_Should
    {
        [Test]
        public void ReturnProperView()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }
    }
}
