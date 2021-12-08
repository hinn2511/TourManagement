using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TourManagement.DAL;
using TourManagement.BUS;

namespace Web.Controllers
{
    public class LoaiTourController : Controller
    {
        Bus_LoaiTour bus = new Bus_LoaiTour();
        // Lay danh sach loai tour
        public ActionResult Index(string searchString)
        {
            var dsLoaiTour = bus.LayDanhSachLoaiTour();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsLoaiTour = bus.TimKiemLoaiTour(dsLoaiTour, searchString);
            }
            return View(dsLoaiTour);
        }

        ////Tra ve trang tao loai tour moi
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        ////Tao loai tour moi
        [HttpPost]
        public ActionResult Create(TourManagement.LoaiTour loaiTour)
        {
            if (string.IsNullOrEmpty(loaiTour.TenLoai))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                return View(loaiTour);
            }
            else
            {
                bus.ThemLoaiTour(loaiTour);
                return RedirectToAction("Index");
            } 
            
        }

        //Sua loai tour

        ////Tra ve trang sua loai tour
        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayChiTietLoaiTour(id);
            return View(chiTiet);
        }

        ////Sua loai tour
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.LoaiTour loaiTour)
        {
            if (string.IsNullOrEmpty(loaiTour.TenLoai))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                return View(loaiTour);
            }
            else
            {
                bus.CapNhatLoaiTour(loaiTour);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayChiTietLoaiTour(id);
            return View(chiTiet);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
                bus.XoaLoaiTour(id);
                return RedirectToAction("Index");
            
        }
    }
}