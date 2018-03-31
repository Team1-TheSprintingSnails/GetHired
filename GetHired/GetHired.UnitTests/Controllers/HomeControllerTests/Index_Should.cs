using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnProperView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
