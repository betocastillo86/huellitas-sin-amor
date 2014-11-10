using System.Web;
using System.Web.Optimization;

namespace LoginCol.Huellitas.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundles/backbone").Include(
                "~/Scripts/libs/json2.js",
                "~/Scripts/libs/underscore.js",
                "~/Scripts/libs/backbone.js",
                "~/Scripts/libs/backbone-validation.js",
                "~/Scripts/libs/backbone.stickit.js"
                
                        
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/libs/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/libs/jquery.unobtrusive*",
                        "~/Scripts/libs/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/huellitas")
                .Include("~/Scripts/huellitas.general.js")
                .Include("~/Home/ConstantesJs"));

            bundles.Add(new ScriptBundle("~/bundles/slide").Include(
                "~/Scripts/libs/jquery.cbpFWSlider.js"));

            


            //Librerias adicionales del template charisma
            bundles.Add(new ScriptBundle("~/bundles/jqueryTemplate").
                Include(
                "~/Scripts/libs/jquery.cookie.js",
                "~/Scripts/libs/jquery.dataTables.js",
                                "~/Scripts/libs/jquery.raty.js",
                                "~/Scripts/libs/jquery.iphone.toggle.js",
                                "~/Scripts/libs/jquery.autogrow-textarea.js",
                                "~/Scripts/libs/jquery.uploadify-3.1.js",
                                "~/Scripts/libs/jquery.history.js",
                                "~/Scripts/libs/charisma.js",
                                "~/Scripts/libs/jquery.noty.js",
                                "~/Scripts/libs/responsive-tables.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/libs/bootstrap.js",
                    "~/Scripts/libs/bootstrap-tour.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                    "~/Scripts/libs/moment/moment.js"    ,
                    "~/Scripts/libs/fullcalendar/fullcalendar.js"
                    
                    ));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                    "~/Scripts/libs/chosen/chosen.jquery.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/colorbox").Include(
                    "~/Scripts/libs/colorbox/jquery.colorbox.js"
                    ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Content/site.css"));


            bundles.Add(new StyleBundle("~/bundles/cssfrontend")
                .Include("~/Content/normalize.css")
                .Include("~/Content/slider.css")
                .Include("~/Content/grid.css")
                .Include("~/Content/menu_styles.css")
                .Include("~/Content/style.css"));


            bundles.Add(new ScriptBundle("~/bundles/frontend")
                .Include("~/Scripts/libs/modernizr_menu.js")
                .Include("~/Scripts/libs/jquery.stellar.js")
                .Include("~/Scripts/libs/waypoints.js")
                .Include("~/Scripts/libs/menu.js")
                //.Include("~/Scripts/libs/jquery.jscroll.js")
                .Include("~/Scripts/libs/jquery.easing.1.3.js")
                //.Include("~/Scripts/libs/huellitas.front.init.js")
                .Include("~/Scripts/libs/TrafficCop.js"));


            bundles.Add(new StyleBundle("~/bundles/themes/base/css").Include(
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


            bundles.Add(new StyleBundle("~/bundles/Admin").Include(
                "~/Content/Admin/charisma-app.css",
                "~/Content/Admin/fullcalendar.css",
                "~/Content/Admin/fullcalendar.print.css",
                "~/Content/Admin/chosen.css",
                "~/Content/Admin/colorbox.css",
                "~/Content/Admin/responsive-tables.css",
                "~/Content/Admin/bootstrap-tour.css",
                "~/Content/Admin/jquery.noty.css",
                "~/Content/Admin/noty_theme_default.css",
                "~/Content/Admin/elfinder.css",
                "~/Content/Admin/elfinder.theme.css",
                "~/Content/Admin/jquery.iphone.toggle.css",
                "~/Content/Admin/uploadify.css",
                "~/Content/Admin/animate.css"));


            


        }
    }
}