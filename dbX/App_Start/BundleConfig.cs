﻿using System.Web;
using System.Web.Optimization;

namespace dbX
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/quill").Include(
                    "~/Scripts/quill.js",
                    "~/Scripts/quill.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/intro").Include(
                    "~/Scripts/intro.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                    "~/Scripts/ace/*.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles.css",
                      "~/Content/quill.base.css",
                      "~/Content/quill.snow.css",
                      "~/Content/introjs.css"));
        }
    }
}
