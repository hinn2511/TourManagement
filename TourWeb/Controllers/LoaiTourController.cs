using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManagement.DAL;
using TourManagement.BUS;

namespace Web.Controllers
{
    public class LoaiTourController : Controller
    {
        Bus_LoaiTour bus = new Bus_LoaiTour();
        // Lay danh sach loai tour
        public IActionResult Index(string searchString)
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
        public IActionResult Create()
        {
            return View();
        }

        ////Tao loai tour moi
        [HttpPost]
        public IActionResult Create(TourManagement.LoaiTour loaiTour)
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
        public IActionResult Edit(int id)
        {
            var chiTiet = bus.LayChiTietLoaiTour(id);
            return View(chiTiet);
        }

        ////Sua loai tour
        [HttpPost]
        public IActionResult Edit(int id, TourManagement.LoaiTour loaiTour)
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

        public IActionResult Delete(int id)
        {
            var chiTiet = bus.LayChiTietLoaiTour(id);
            return View(chiTiet);
        }

        [HttpPost]
        public IActionResult Delete(int id, TourManagement.LoaiTour loaiTour)
        {
                bus.XoaLoaiTour(id);
                return RedirectToAction("Index");
            
        }
    }
}