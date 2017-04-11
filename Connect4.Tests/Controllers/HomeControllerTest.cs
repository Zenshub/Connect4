using NUnit.Framework;
using System.Web.Mvc;
using Connect4.Controllers;
using System.Web;
using System;

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

		[Test]
		public void TestSession_WhenRestart_WithInputs()
		{
			var view = controller.Restart(5, 5) as ViewResult;
			var result = controller.Session["Model"] as Board;

			var expected = new Board(5, 5);

			Assert.AreEqual(new BoardComparer().Compare(result, expected), 0);

		}

		[Test]
		public void TestController_WhenRestart_Redirect()
		{
			var view = controller.Restart(5, 5) as ActionResult;

			Assert.That(view, Is.InstanceOf<RedirectToRouteResult>());

		}

	}
}