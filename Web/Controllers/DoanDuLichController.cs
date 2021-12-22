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
    public class DoanDuLichController : Controller
    {
        Bus_DoanDuLich bus = new Bus_DoanDuLich();
        Dto_Tour currentTour;

        // GET: Doan Du Lich
        public ActionResult Index(String searchString)
        {
            var dsDoanDuLich = bus.LayDanhSachDoanDuLich();
           
            if (!string.IsNullOrEmpty(searchString))
            {
                dsDoanDuLich = bus.TimKiemDoanDuLich(dsDoanDuLich, searchString);
            }
            return View(dsDoanDuLich);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(TourManagement.DTO.Dto_DoanDuLich doanDuLich)
        {
            if (string.IsNullOrEmpty(doanDuLich.TenDoan))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(doanDuLich);
            }
            else
            {
                bus.ThemDoanDuLich(doanDuLich);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinDoanDuLich(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.DTO.Dto_DoanDuLich doanDuLich)
        {
            if (string.IsNullOrEmpty(doanDuLich.TenDoan))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(doanDuLich);
            }
            else
            {
                bus.CapNhatDoanDuLich(doanDuLich);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var chiTiet = bus.LayThongTinDoanDuLich(id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            bus.XoaDoanDuLich(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            Bus_ChiTietDoan bus = new Bus_ChiTietDoan();
            List<Dto_ChiTietDoan> model = new List<Dto_ChiTietDoan>();
            model = bus.LayDanhSachChiTietDoan(id);
            return View(model);
        }
    }
}