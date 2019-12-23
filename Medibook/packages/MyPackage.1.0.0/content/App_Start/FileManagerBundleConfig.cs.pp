

using System.Web.Optimization;

namespace $rootnamespace$
{
    public class FileManagerBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/FileManager/js").Include(
                  "~/Scripts/jquery-{version}.js",
                  "~/Scripts/fileManager/bootstrap.js",
                  "~/Scripts/fileManager/bootstrap-lightbox.js",
                  "~/Scripts/fileManager/dropzone.js"
                 ));

            bundles.Add(new StyleBundle("~/FileManager/css").Include(
                "~/Content/filemanager/css/fileManager/bootstrap.css",
                "~/Content/filemanager/css/fileManager/bootstrap-lightbox.css",
                "~/Content/filemanager/css/fileManager/style.css",
                "~/Content/filemanager/css/fileManager/dropzone.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/filemanager/themes/base/jquery.ui.core.css",
                        "~/Content/filemanager/themes/base/jquery.ui.resizable.css",
                        "~/Content/filemanager/themes/base/jquery.ui.selectable.css",
                        "~/Content/filemanager/themes/base/jquery.ui.accordion.css",
                        "~/Content/filemanager/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/filemanager/themes/base/jquery.ui.button.css",
                        "~/Content/filemanager/themes/base/jquery.ui.dialog.css",
                        "~/Content/filemanager/themes/base/jquery.ui.slider.css",
                        "~/Content/filemanager/themes/base/jquery.ui.tabs.css",
                        "~/Content/filemanager/themes/base/jquery.ui.datepicker.css",
                        "~/Content/filemanager/themes/base/jquery.ui.progressbar.css",
                        "~/Content/filemanager/themes/base/jquery.ui.theme.css"));
        }

    }
}