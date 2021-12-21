using System.Diagnostics;
using System.Web.Mvc;
using TourManagement.BUS;
using Web.Models;

namespace Web.Controllers
{
    public class TourController : Controller
    {
        Bus_Tour bus = new Bus_Tour();

        public ActionResult Index(string searchString)
        {
            var dsTour = bus.LayDanhSachTour();
            if (!string.IsNullOrEmpty(searchString))
            {
                dsTour = bus.TimKiemTour(dsTour, searchString);
            }
            return View(dsTour);
        }

        public ActionResult Detail(int id)
        {
            TourDetail model = new TourDetail();
            model.tour = bus.LayThongTinTour(id);
            var gia = bus.LayGiaTour(id);
            if(gia != null)
                model.gia = gia;    
            else
                model.gia = null;
            model.dsThamQuan = bus.LayLichTrinhThamQuan(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.loaiTourList = new SelectList(bus.LayDanhSachLoaiTour(), "Id", "TenLoai");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TourManagement.DTO.Dto_Tour dto_Tour)
        {
            if (string.IsNullOrEmpty(dto_Tour.TenTour) || string.IsNullOrEmpty(dto_Tour.DacDiem) || dto_Tour.Loai_Id <= 0)
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                ViewBag.loaiTourList = new SelectList(bus.LayDanhSachLoaiTour(), "Id", "TenLoai");
                return View(dto_Tour);
            }
            else
            {
                bus.ThemTourMoi(dto_Tour);
                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(int id)
        {
            var chiTiet = bus.LayThongTinTour(id);
            ViewBag.loaiTourList = new SelectList(bus.LayDanhSachLoaiTour(), "Id", "TenLoai");
            return View(bus.convertToDto(chiTiet));
        }

        [HttpPost]
        public ActionResult Edit(TourManagement.DTO.Dto_Tour dto)
        {
            if (string.IsNullOrEmpty(dto.TenTour) || string.IsNullOrEmpty(dto.DacDiem))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                ViewBag.loaiTourList = new SelectList(bus.LayDanhSachLoaiTour(), "Id", "TenLoai");
                return View(dto);
            }
            else
            {
                bus.SuaThongTinTour(dto);
                return RedirectToAction("Index");
            }
        }
    }
}