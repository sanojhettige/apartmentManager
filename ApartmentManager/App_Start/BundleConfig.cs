using System.Web;
using System.Web.Optimization;

namespace ApartmentManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                           "~/Assets/Vendor/jquery/jquery.min.js",
                           "~/Assets/Vendor/bootstrap/js/bootstrap.bundle.min.js",
                            "~/Assets/Vendor/jquery-easing/jquery.easing.min.js",
                            "~/Assets/Scripts/bootbox.js",
                            "~/Assets/Scripts/respond.js",
                            "~/Assets/Vendor/datatables/jquery.dataTables.min.js",
                            "~/Assets/Vendor/datatables/dataTables.bootstrap4.min.js",
                           "~/Assets/scripts/typeahead.bundle.js",
                           "~/Assets/scripts/toastr.js",
                             "~/Assets/scripts/bloodhound.js"
                             ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker-js").Include(
                        "~/Assets/Vendor/date-picker/bootstrap-datepicker.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Assets/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Assets/Vendor/fontawesome-free/css/all.min.css",
                        "~/Assets/Vendor/datatables/dataTables.bootstrap4.min.css",
                        "~/Assets/Content/typeahead.css",
                        "~/Assets/Content/toastr.css",
                        "~/Assets/Content/app.css"
                      ));
            bundles.Add(new StyleBundle("~/bundles/datepicker-css").Include(
                        "~/Assets/Vendor/date-picker/bootstrap-datepicker.css"));
        }
    }
}
