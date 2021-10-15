using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GioiThieuSanPham
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //danh sách sản phẩm
            routes.MapRoute(
                 name: "Danh sach san pham",
                     url: "danh-sach-san-pham",
                 defaults: new { controller = "SanPham", action = "DanhSachSanPham", id = UrlParameter.Optional }
            );

            //MẶC ĐỊNH
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"GioiThieuSanPham.Controllers"}
            );
        }
    }
}
