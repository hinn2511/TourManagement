using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourManagement.DAL;
using TourManagement.BUS;
using TourManagement.DTO;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ChiPhiController : Controller
    {
        Bus_ChiPhi bus = new Bus_ChiPhi();
        Dto_DoanDuLich currentDoanDuLich;

        // GET: ChiPhi 
        public ActionResult Index(String searchString)
        {
            var dsChiPhi = bus.LayDanhSachChiPhi(currentDoanDuLich.Id);
            if (!string.IsNullOrEmpty(searchString))
            {
                dsChiPhi = bus.TimKiem(dsChiPhi, searchString);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(TourManagement.DTO.Dto_ChiPhi chiPhi)
        {
            if (string.IsNullOrEmpty(chiPhi.TenLoaiChiPhi))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(chiPhi);
            }
            else
            {
                bus.ThemChiPhi(chiPhi);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinChiPhi(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.DTO.Dto_ChiPhi chiPhi)
        {
            if (string.IsNullOrEmpty(chiPhi.TenLoaiChiPhi))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(chiPhi);
            }
            else
            {
                bus.CapNhatChiPhi(chiPhi);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayThongTinChiPhi(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaChiPhi(id);
            return RedirectToAction("Index");
        }
    }
}