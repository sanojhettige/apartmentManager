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

            bundles.Add(new ScriptBundle("~/bundles/report-js").Include(
                "~/Assets/Vendor/datatables/dataTables.buttons.min.js",
                "~/Assets/Vendor/datatables/buttons.flash.min.js",
                "~/Assets/Vendor/datatables/jszip.min.js",
                "~/Assets/Vendor/datatables/pdfmake.min.js",
                "~/Assets/Vendor/datatables/vfs_fonts.js",
                "~/Assets/Vendor/datatables/buttons.html5.min.js",
                "~/Assets/Vendor/datatables/buttons.print.min.js"
                ));

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
            bundles.Add(new StyleBundle("~/bundles/report-css").Include(
                "~/Assets/Vendor/datatables/buttons.dataTables.min.css"
                ));
        }
    }
}
