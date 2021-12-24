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

        // GET: ChiPhi 
        public ActionResult Index(int id)
        {
            var dsChiPhi = bus.LayDanhSachChiPhi(id);
            ViewBag.TenDoan = bus.LayTenDoan(id);
            ViewBag.DoanId = id;
            return View(dsChiPhi);
        }
        public ActionResult Create(int id)
        {
            ViewBag.loaiChiPhiList = new SelectList(bus.LayDanhSachLoaiChiPhi(), "Id", "TenLoai");
            Dto_ChiPhi chiPhi = new Dto_ChiPhi();
            chiPhi.DoanDuLich_Id = id;
            return View(chiPhi);
        }

        [HttpPost]
        public ActionResult Create(TourManagement.DTO.Dto_ChiPhi chiPhi)
        {
            if (chiPhi.LoaiChiPhi_id <=0 || chiPhi.SoTien ==0)
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(chiPhi);
            }
            else
            {
                bus.ThemChiPhi(chiPhi);
                return RedirectToAction("Index", "ChiPhi", new {id = chiPhi.DoanDuLich_Id});
            }
        }

        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinChiTietChiPhi(id);
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

        public ActionResult Delete(int id, int IdDoan)
        {
            var chiTiet = bus.LayThongTinChiTietChiPhi(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, int IdDoan, FormCollection formCollection)
        {
            bus.XoaChiPhi(id);
            return RedirectToAction("Index", "ChiPhi", new {id = IdDoan});
        }
    }
}