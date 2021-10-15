using GioiThieuSanPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GioiThieuSanPham.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult DanhSachSanPham()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            //lấy ra danh sách các sản phẩm
            List<SanPham> ketQua = db.SanPhams.ToList();
            return View(ketQua);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            //tìm ra đối tượng trong cơ sở dữ liệu
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            SanPham ketQua = db.SanPhams.Find(id);
            return View(ketQua);
        }
        public ActionResult ThemMoi()
        {
            return View(new SanPham() { GiaBanCu = 0, GiaBanMoi = 0 });
        }
        [HttpPost]
        public ActionResult ThemMoi(SanPham model)
        {
            //lưu dữ liệu vào db
            if (string.IsNullOrEmpty(model.TenSanPham) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(model);
            }
            if (model.GiaBanMoi <= 0)
            {
                ModelState.AddModelError("", "Giá bán phải lớn hơn 0");
                return View(model);
            }
            //lưu
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            //hàm thêm mới
            db.SanPhams.Add(model);
            //hàm lưu dữ liệu
            db.SaveChanges();
            if (model.ID > 0)
            {
                return RedirectToAction("DanhSachSanPham");

            }
            else
            {
                ModelState.AddModelError("", "không lưu được vào cơ sở dữ liệu");
                return View(model);
            }


        }
        public ActionResult CapNhat(int id)
        {
            //tìm sản phẩm cần cập nhật
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var sanPhamModel = db.SanPhams.Find(id);
            return View(sanPhamModel);
        }
        [HttpPost]
        public ActionResult CapNhat(SanPham model)
        {
            //tìm sản phẩm cần cập nhật
            //lưu dữ liệu vào db
            if (string.IsNullOrEmpty(model.TenSanPham) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(model);
            }
            if (model.GiaBanMoi <= 0)
            {
                ModelState.AddModelError("", "Giá bán phải lớn hơn 0");
                return View(model);
            }
            //lưu 
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var id = db.SaveChanges();
            if (id > 0)
            {
                return RedirectToAction("DanhSachSanPham");

            }
            return View(model);
        }
        public ActionResult Xoa(int id)
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var model = db.SanPhams.Find(id);
            db.SanPhams.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSachSanPham");
        }
        public ActionResult DanhSach()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            //truy vấn toàn bộ: select * from table
            var ketQua = (from item in db.SanPhams select item).ToList();
            //truy vấn có điều kiện: select * from table where...
            var ketQua2 = (from item in db.SanPhams where item.GiaBanMoi <= 1000000 select item).ToList();
            //sắp xếp: select * from table orderby <trường>
            var ketQua3 = (from item in db.SanPhams orderby item.GiaBanMoi descending select item).ToList();
            //kết nối giữa hai bảng: select * from table1 inner join table2 on Table1.khoa = table2.khoa
            var ketQua4 = (from sp in db.SanPhams
                           join hangSX in db.HangSanXuats on sp.idHang equals hangSX.ID
                           select sp).ToList();
            //lọc trùng: select Distinct * from table
            var ketQua5 = (from sp in db.SanPhams
                           join hangSX in db.HangSanXuats on sp.idHang equals hangSX.ID
                           select hangSX).Distinct().ToList();
            return View(ketQua4);
        }
    }
}