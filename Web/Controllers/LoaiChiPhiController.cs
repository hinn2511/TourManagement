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
    public class LoaiChiPhiController : Controller
    {
        Bus_LoaiChiPhi bus = new Bus_LoaiChiPhi();
        // GET: LoaiChiPhi
        public ActionResult Index(string searchString)
        {
            var dsLoaiChiPhi = bus.LayDanhSachLoaiChiPhi();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsLoaiChiPhi = bus.TimKiem(dsLoaiChiPhi, searchString);
            }
            return View(dsLoaiChiPhi);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TourManagement.LoaiChiPhi loaiChiPhi)
        {
            if (string.IsNullOrEmpty(loaiChiPhi.TenLoai))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(loaiChiPhi);
            }
            else
            {
                bus.ThemLoaiChiPhi(loaiChiPhi);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinLoaiChiPhi(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.LoaiChiPhi loaiChiPhi)
        {
            if (string.IsNullOrEmpty(loaiChiPhi.TenLoai))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(loaiChiPhi);
            }
            else
            {
                bus.CapNhatLoaiChiPhi(loaiChiPhi);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayThongTinLoaiChiPhi(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaLoaiChiPhi(id);
            return RedirectToAction("Index");
        }
    }


}