using System;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace Connect4.Tests
{
	public class MockHttp
	{
		public static HttpContext FakeHttpContext(string url)
		{
			var uri = new Uri(url);
			var httpRequest = new HttpRequest(string.Empty, uri.ToString(),
							  uri.Query.TrimStart('?'));
			var stringWriter = new StringWriter();
			var httpResponse = new HttpResponse(stringWriter);
			var httpContext = new HttpContext(httpRequest, httpResponse);

			var sessionContainer = new HttpSessionStateContainer(
				"id",
				new SessionStateItemCollection(),
				new HttpStaticObjectsCollection(),
				10, true, HttpCookieMode.AutoDetect,
				SessionStateMode.InProc, false);

			SessionStateUtility.AddHttpSessionStateToContext(httpContext, sessionContainer);

			return httpContext;
		}

		public static void SetUpCurrentContext()
		{
			HttpContext.Current = MockHttp.FakeHttpContext("http://localhost:8080");

		}
	}
}
