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
    public class ThamQuanController : Controller
    {
        Bus_ThamQuan bus = new Bus_ThamQuan();
        // GET: GiaTour
        public ActionResult Index(int id)
        {
            var dsThamQuan = bus.LayDanhSachThamQuan(id);
            ViewBag.TenTour = bus.LayTenTour(id);
            ViewBag.TourId = id;
            return View(dsThamQuan);
        }

        public ActionResult Create(int id)
        {
            ViewBag.diaDiemList = new SelectList(bus.LayDanhSachDiaDiem(id), "Id", "TenDiaDiem");
            Dto_ThamQuan thamQuan = new Dto_ThamQuan();
            thamQuan.Tour_Id = id;
            return View(thamQuan);
        }


        [HttpPost]
        public ActionResult Create(Dto_ThamQuan thamQuan)
        {
            if (thamQuan.DiaDiem_Id <= 0)
            {

                ViewBag.Error = "Vui lòng chọn địa điểm";
                return View(thamQuan);
            }
            bus.ThemThamQuan(thamQuan);
            return RedirectToAction("Index", "ThamQuan", new { id = thamQuan.Tour_Id });
        }

        public ActionResult Edit(int tourId, int diaDiemId)
        {
            var chiTietThamQuan = bus.ChiTietThamQuan(tourId, diaDiemId);
            int soLuongHienTai = bus.LaySoLuongDiaDiem(tourId);
            Dictionary<int,string> dsThuTu = new Dictionary<int, string>();
            for (int i = 1; i <= soLuongHienTai; i++)
            {
                if (i != chiTietThamQuan.ThuTu)
                    dsThuTu.Add(i, "Thứ tự " + i);
            }
            ViewBag.dsThuTu = new SelectList(dsThuTu, "Key", "Value");
            return View(chiTietThamQuan);
        }

        [HttpPost]
        public ActionResult Edit(Dto_ThamQuan thamQuan)
        {
            bus.SuaLichTrinhThamQuan(thamQuan);
            return RedirectToAction("Index", "ThamQuan", new { id = thamQuan.Tour_Id });
        }

        public ActionResult Delete(int tourId, int diaDiemId)
        {
            var chiTietThamQuan = bus.ChiTietThamQuan(tourId, diaDiemId);
            ViewBag.TenTour = bus.LayTenTour(chiTietThamQuan.Tour_Id);
            return View(chiTietThamQuan);
        }

        [HttpPost]
        public ActionResult Delete(int tourId, int diaDiemId, FormCollection collection)
        {
            bus.XoaThamQuan(tourId, diaDiemId);
            return RedirectToAction("Index", "ThamQuan", new { id = tourId });
        }
    }
}
