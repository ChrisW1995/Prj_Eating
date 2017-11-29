using System.Web;
using System.Web.Optimization;

namespace Eating
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           // BundleTable.EnableOptimizations;
            //////
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.validate*",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                         "~/Scripts/DataTables/dataTables.bootstrap.js",
                         "~/Scripts/Chart.js",
                         "~/Scripts/bootbox.js",
                        "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js",
                         "~/Content/dist/js/demo.js",
                         "~/Content/dist/js/app.js"
                         ));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                     "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datetimepickercss").Include(
                 "~/Content/bootstrap-datetimepicker.min.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/jquery-ui.css",
                    "~/Content/jquery-ui.theme.css",
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/SideMenu.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/layout").Include(
                    "~/Content/jquery-ui.css",
                    "~/Content/jquery-ui.theme.css",
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/Content/Layout2_css.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/fileupload").Include(
                                        "~/Content/jQuery.FileUpload/css/jquery.fileupload.css",
                   "~/Content/jQuery.FileUpload/css/jquery.fileupload-ui.css",
                              "~/Content/blueimp-gallery2/css/blueimp-gallery.css",
                     "~/Content/blueimp-gallery2/css/blueimp-gallery-video.css",
                       "~/Content/blueimp-gallery2/css/blueimp-gallery-indicator.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                        "~/Scripts/bootbox.js",
                        "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js",
                         "~/Content/dist/js/demo.js",
                         "~/Content/dist/js/app..js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jQuery-File-Upload").Include(
                        //<!-- The Templates plugin is included to render the upload/download listings -->
                        "~/Scripts/jQuery.FileUpload/vendor/jquery.ui.widget.js",
                          "~/Scripts/jQuery.FileUpload/tmpl.min.js",
   //<!-- The Load Image plugin is included for the preview images and image resizing functionality -->
   "~/Scripts/jQuery.FileUpload/load-image.all.min.js",
   //<!-- The Canvas to Blob plugin is included for image resizing functionality -->
   "~/Scripts/jQuery.FileUpload/canvas-to-blob.min.js",
   //"~/Scripts/file-upload/jquery.blueimp-gallery.min.js",
   //<!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
   "~/Scripts/jQuery.FileUpload/jquery.iframe-transport.js",
   //<!-- The basic File Upload plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload.js",
   //<!-- The File Upload processing plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-process.js",
   //<!-- The File Upload image preview & resize plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-image.js",
   //<!-- The File Upload audio preview plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-audio.js",
   //<!-- The File Upload video preview plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-video.js",
   //<!-- The File Upload validation plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-validate.js",
   //!-- The File Upload user interface plugin -->
   "~/Scripts/jQuery.FileUpload/jquery.fileupload-ui.js",
   //Blueimp Gallery 2 
   "~/Scripts/blueimp-gallery2/js/blueimp-gallery.js",
   "~/Scripts/blueimp-gallery2/js/blueimp-gallery-video.js",
   "~/Scripts/blueimp-gallery2/js/blueimp-gallery-indicator.js",
   "~/Scripts/blueimp-gallery2/js/jquery.blueimp-gallery.js"

   ));
            bundles.Add(new ScriptBundle("~/bundles/Blueimp-Gallerry2").Include(//Blueimp Gallery 2 
"~/Scripts/blueimp-gallery2/js/blueimp-gallery.js",
"~/Scripts/blueimp-gallery2/js/blueimp-gallery-video.js",
"~/Scripts/blueimp-gallery2/js/blueimp-gallery-indicator.js",
"~/Scripts/blueimp-gallery2/js/jquery.blueimp-gallery.js"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                      "~/Content/Admin.css",
                      "~/Content/Admin.postcss.css"
                      ));

        }
    }
}
