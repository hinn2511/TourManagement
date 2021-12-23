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

    public class NhanVienController : Controller
    {
        Bus_NV bus = new Bus_NV();
        // Lay danh sach loai tour
        public ActionResult Index(string searchString)
        {
            var dsNV = bus.LayDanhSachNV();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsNV = bus.TimKiemNV(dsNV, searchString);
            }
            return View(dsNV);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TourManagement.NhanVien nv)
        {
            if (string.IsNullOrEmpty(nv.HoTen))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(nv);
            }
            else
            {
                bus.ThemNV(nv);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinNV(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.NhanVien nv)
        {
            if (string.IsNullOrEmpty(nv.HoTen))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(nv);
            }
            else
            {
                bus.CapNhatNV(nv);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayThongTinNV(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaNV(id);
            return RedirectToAction("Index");
        }
    }
}