using System.Web;
using System.Web.Optimization;

namespace framework.cspnetworks.net
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui.*"));

            //bundles.Add(new StyleBundle("~/bundles/jqueryui-css").Include(
            //            "~/Content/jquery-ui/jquery-ui.*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Scripts/bootstrap-datepicker/bootstrap-*"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-datepicker-css").Include(
                        "~/Content/bootstrap-datepicker/bootstrap-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/maskedEdit").Include(
                "~/Scripts/masked-edit/jquery.mask.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
            //   "~/Scripts/jqGrid/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-table").Include(
              "~/Scripts/bootstrap-table/bootstrap-table.js",
             "~/Scripts/bootstrap-table/bootstrap-table-en.js"));
            
             //bundles.Add(new ScriptBundle("~/bundles/bootstrap-tooltip").Include(
             //"~/Scripts/bootstrap-tooltip/bootstrap-tooltip.js",
             //"~/Scripts/bootstrap-tooltip/bootstrap-popover.js"));

            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/login/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/login.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                     "~/Content/bootstrap.css",
                     
                     "~/Content/flatfont.css"));

            //bundles.Add(new StyleBundle("~/Content/jqGrid/css").Include(
            //       "~/Content/jqGrid/*.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-table/css").Include(
                   "~/Content/bootstrap-table/*.css"));   
        }
    }
}
