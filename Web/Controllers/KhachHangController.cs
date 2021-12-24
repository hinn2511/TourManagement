using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagement.DAL;
using TourManagement.BUS;
using System.Threading.Tasks;

namespace Web.Controllers
{

    public class KhachHangController : Controller
    {
        Bus_KH bus = new Bus_KH();
        // Lay danh sach kh
        public ActionResult Index(string searchString)
        {
            var dsKH = bus.LayDanhSachKH();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsKH = bus.TimKiemKH(dsKH, searchString);
            }
            return View(dsKH);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TourManagement.KhachHang kh)
        {
            if (string.IsNullOrEmpty(kh.HoTen))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(kh);
            }
            else
            {
                bus.ThemKH(kh);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinKH(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.KhachHang kh)
        {
            if (string.IsNullOrEmpty(kh.HoTen))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(kh);
            }
            else
            {
                bus.CapNhatKH(kh);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayThongTinKH(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaKH(id);
            return RedirectToAction("Index");
        }
    }
}