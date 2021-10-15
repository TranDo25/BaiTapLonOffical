﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GioiThieuSanPham.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string username, string password)
        {
            if (username == "admin" & password == "123456")
            {
                Session.Add("user", username);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

    }
}