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

    public class DiaDiemController : Controller
    {
        Bus_DiaDiem bus = new Bus_DiaDiem();
        // Lay danh sach loai tour
        public ActionResult Index(string searchString)
        {
            var dsDiaDiem= bus.LayDanhSachDiaDiem();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsDiaDiem = bus.TimKiemDiaDiem(dsDiaDiem, searchString);
            }
            return View(dsDiaDiem);
        }
        [HttpGet]
        public ActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult Create (TourManagement.DiaDiem diaDiem)
        {
            if (string.IsNullOrEmpty(diaDiem.TenDiaDiem))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(diaDiem);
            }
            else
            {
                bus.ThemDiaDiem(diaDiem);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(int id) {
            var chiTiet = bus.LayThongTinDiaDiem(id);
            return View(chiTiet); 
        }
        [HttpPost]
        public ActionResult Edit(int id, TourManagement.DiaDiem diaDiem) {
            if (string.IsNullOrEmpty(diaDiem.TenDiaDiem))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(diaDiem);
            }
            else
            {
                bus.CapNhatDiaDiem(diaDiem);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete (int id)
        {
            var chiTiet = bus.LayThongTinDiaDiem (id);
            return View(chiTiet);
        }
        [HttpPost]
        public ActionResult Delete (int id, FormCollection formCollection)
        {
            bus.XoaDiaDiem(id);
            return RedirectToAction("Index");
        }
    }
}