using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagement.BUS;
using TourManagement.DTO;

namespace Web.Controllers
{
    public class GiaTourController : Controller
    {
        Bus_GiaTour bus = new Bus_GiaTour();

        public ActionResult Index(int id)
        {
            var dsGia = bus.LayDanhSachGiaTour(id);
            ViewBag.TenTour = bus.LayTenTour(id);
            ViewBag.TourId = id;
            return View(dsGia);
        }

        public ActionResult Create(int id)
        {
            ViewBag.TenTour = bus.LayTenTour(id);
            Dto_GiaTour gia = new Dto_GiaTour();
            gia.Tour_Id = id;
            return View(gia);
        }

        [HttpPost]
        public ActionResult Create(Dto_GiaTour dto_GiaTour)
        {
            if (!bus.KiemTraNgayGiaTour(dto_GiaTour.Tour_Id, dto_GiaTour.NgayBatDau, dto_GiaTour.NgayKetThuc))
            {
                ViewBag.Error = "Đã tồn tại giá tour trong khoảng thời gian từ " + dto_GiaTour.NgayBatDau.ToShortDateString() + " đến " + dto_GiaTour.NgayKetThuc.ToShortDateString();
                return View(dto_GiaTour);
            } 
                
            if (dto_GiaTour.NgayBatDau > dto_GiaTour.NgayKetThuc)
            {

                ViewBag.Error = "Ngày áp dụng không hợp lệ";
                return View(dto_GiaTour);
            }
            if (dto_GiaTour.Gia <= 0)
            {

                ViewBag.Error = "Giá tour không hợp lệ";
                return View(dto_GiaTour);
            }
            
            bus.ThemGiaTour(dto_GiaTour);
            return RedirectToAction("Index", "GiaTour", new { id = dto_GiaTour.Tour_Id });
            
        }

        public ActionResult Edit(int id)
        {
            var chiTietGiaTour = bus.ChiTietGiaTour(id);
            ViewBag.TenTour = bus.LayTenTour(chiTietGiaTour.Tour_Id);
            return View(chiTietGiaTour);
        }

        [HttpPost]
        public ActionResult Edit(Dto_GiaTour dto_GiaTour)
        {
            if (dto_GiaTour.Gia <= 0)
            {
                ViewBag.Error = "Giá tour không hợp lệ";
                return View(dto_GiaTour);
            }
            if (dto_GiaTour.NgayBatDau >= dto_GiaTour.NgayKetThuc)
            {
                ViewBag.Error = "Ngày áp dụng không hợp lệ";
                return View(dto_GiaTour);
            }
            bus.SuaGiaTour(dto_GiaTour);
            return RedirectToAction("Index", "GiaTour", new { id = dto_GiaTour.Tour_Id });
        }

        public ActionResult Delete(int id)
        {
            var chiTietGiaTour = bus.ChiTietGiaTour(id);
            ViewBag.TenTour = bus.LayTenTour(chiTietGiaTour.Tour_Id);
            return View(chiTietGiaTour);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var chiTietGiaTour = bus.ChiTietGiaTour(id);
            if (chiTietGiaTour.DangApDung)
            {
                ViewBag.Error = "Không thể xóa giá tour đang áp dụng";
                ViewBag.TenTour = bus.LayTenTour(chiTietGiaTour.Tour_Id);
                return View(chiTietGiaTour);
            }
            DateTime now = DateTime.Now;
            if (chiTietGiaTour.NgayKetThuc < now)
            {
                ViewBag.Error = "Không thể xóa giá tour đã áp dụng";
                ViewBag.TenTour = bus.LayTenTour(chiTietGiaTour.Tour_Id);
                return View(chiTietGiaTour); 
            }
            bus.XoaGiaTour(id);
            return RedirectToAction("Index", "GiaTour", new { id = chiTietGiaTour.Tour_Id });
        }
    }
}
