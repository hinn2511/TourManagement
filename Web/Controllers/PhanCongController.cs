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
    public class PhanCongController : Controller
    {
        Bus_PhanCong bus = new Bus_PhanCong();

        // GET: GiaTour
        public ActionResult Index(int id)
        {
            var dsPhanCong = bus.LayDanhSachPhanCong(id);
            ViewBag.NV_Id = id;
            return View(dsPhanCong);
        }

        public ActionResult Create(int id)
        {
            ViewBag.phanCongList = new SelectList(bus.LayDanhSachPhanCong(id), "Id", "TenDoanDuLich");
            Dto_PhanCong phanCong = new Dto_PhanCong();
            phanCong.NV_Id = id;
            return View(phanCong);
        }


        [HttpPost]
        public ActionResult Create(Dto_PhanCong PhanCong)
        {
            if (PhanCong.DoanDuLich_Id <= 0)
            {

                ViewBag.Error = "Vui lòng chọn tên đoàn";
                return View(PhanCong);
            }
            bus.ThemPC(PhanCong);
            return RedirectToAction("Index", "PhanCong", new { id = PhanCong.NV_Id });
        }

        public ActionResult Edit(int NvId, int ddlID)
        {
            var chiTietPhanCong = bus.ChiTietPhanCong(NvId, ddlID);
            return View(chiTietPhanCong);
        }

        [HttpPost]
        public ActionResult Edit(Dto_PhanCong PhanCong)
        {
            bus.SuaPhanCong(PhanCong);
            return RedirectToAction("Index", "PhanCong", new { id = PhanCong.NV_Id });
        }

        [HttpPost]
        public ActionResult Delete(int NvId, int ddlID)
        {
            bus.XoaPC(NvId, ddlID);
            return RedirectToAction("Index", "PhanCong", new { id = NvId });
        }
    }
}
