using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VBATMRC.Infrastructure
{
    public class Utils
    {

        public static string MappedApplicationPath
        {
            get
            {
                if (HttpContext.Current.Request.ApplicationPath == null) return null;
                var appPath = HttpContext.Current.Request.ApplicationPath.ToLower();
                if (appPath == "/")      //a site
                    appPath = "/";
                else if (!appPath.EndsWith(@"/")) //a virtual
                    appPath += @"/";

                string it = System.Web.HttpContext.Current.Server.MapPath(appPath);
                if (!it.EndsWith(@"\"))
                    it += @"\";
                return it;
            }
        }

        public static string GetVirtualPath(string physicalPath)
        {
            string rootpath = HttpContext.Current.Server.MapPath("~/");

            physicalPath = physicalPath.Replace(rootpath, "");
            physicalPath = physicalPath.Replace("\\", "/");

            return "~/" + physicalPath;
        }

        public class DownloadResult : ActionResult
        {

            public DownloadResult() { }

            public DownloadResult(string virtualPath)
            {
                this.VirtualPath = virtualPath;
            }

            public string VirtualPath
            {
                get;
                set;
            }

            public string FileDownloadName
            {
                get;
                set;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                if (!String.IsNullOrEmpty(FileDownloadName))
                {
                    context.HttpContext.Response.AddHeader("content-disposition",
                        "attachment; filename=" + this.FileDownloadName);
                }

                string filePath = context.HttpContext.Server.MapPath(this.VirtualPath);
                context.HttpContext.Response.TransmitFile(filePath);
            }
        }

    }
}