using System.Web.Optimization;

namespace Connect4
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Scripts/jquery-{version}.js")
				.Include("~/Scripts/jquery-ui-{version}.js")
				.Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
				.Include("~/Scripts/modal.js"));

			bundles.Add(new StyleBundle("~/bundles/styles.css")
				.Include("~/Content/game.css")
				.Include("~/Content/flash-messages.css"));
		}

	}
}
