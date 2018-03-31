using System.Web.Mvc;
using GetHired.ASPClient.Controllers;
using NUnit.Framework;

namespace GetHired.UnitTests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Contact_Should
    {
        [Test]
        public void ReturnProperView()
        {
            var controller = new HomeController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }
    }
}
