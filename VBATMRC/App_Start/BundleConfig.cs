using System.Web.Optimization;

namespace VBATMRC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                        "~/Js/Site.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/holder.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-1.9.1.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-1.2.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            //  Respond
            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                        "~/Scripts/html4shiv.js",
                        "~/Scripts/respond.matchmedia.addListener.min.js",
                        "~/Scripts/respond.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add((new ScriptBundle("~/bundles/cal").Include("~/Js/fullcalendar.js",
                "~/Js/fullcalendar.min.js",
                "~/Js/calload.js")));

            bundles.Add((new ScriptBundle("~/bundles/accord").Include("~/Js/accordion.js", "~/Js/acord_init.js")));

            bundles.Add(new StyleBundle("~/bundles/calcss").Include(
                                        "~/Content/tmrcLocal.css",
                                        "~/Content/fullcalendar.css",
                                        "~/Content/fullcalendar.print.css"));



            //const string bscdnpath = "http://nttlsrv01/VBAResourceStore/Content/bootstrap.min.css";
            //const string bsthemecdnpath = "http://nttlsrv01/VBAResourceStore/Content/bootstrap-theme.css";
            //bundles.Add(new StyleBundle("~/Content/bscss", bscdnpath).I;
            bundles.Add(new StyleBundle("~/bundles/bscss").Include(
                                        "~/Content/bootstrap.min.css",
                                        "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/bundles/bscss-ie7").Include("~/Content/bootstrap-ie7.css"));
            
            bundles.Add(new StyleBundle("~/bundles/css-ie8").Include(
                  "~/Content/SiteLocalIE8.css"));
            
            bundles.Add(new StyleBundle("~/bundles/css-ie7").Include(
                  "~/Content/SiteIE7.css",
                  "~/Content/Colors.css"));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/Site.css",
                        "~/Content/Colors.css",
                        "~/Content/SiteLocal.css"));
            
            //const string sitecsscdnpath = "http://nttlsrv01/VBAResourceStore/Content/site.css";
            //bundles.Add(new StyleBundle("~/Content/css",sitecsscdnpath).Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/jqueryuicss").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}