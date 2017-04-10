using NUnit.Framework;
using System.Web.Mvc;
using Connect4.Controllers;
using System.Web;

namespace Connect4.Tests
{
	[TestFixture]
	public class HomeControllerTest
	{
		HomeController controller;

		[SetUp]
		public void InitialiseController()
		{
			MockHttp.SetUpCurrentContext();
			//HttpContext.Current = MockHttp.FakeHttpContext("http://localhost:8080");
			controller = new HomeController();
			controller.ControllerContext = new ControllerContext(HttpContext.Current.Request.RequestContext, controller);
		}

		[Test]
		public void TestIndexView()
		{
			var result = controller.Index(0) as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}

	}
}
