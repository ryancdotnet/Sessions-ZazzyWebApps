using System.Web;
using System.Web.Optimization;

namespace Atlas.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.4.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/atlas").Include(
                        "~/Scripts/atlas.js",
                        "~/Scripts/atlas.status.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/AtlasStyle.css",
                      "~/Content/AtlasStatus.css"));
        }
    }
}
