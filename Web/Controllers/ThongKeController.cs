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
using System.Globalization;

namespace Web.Controllers
{
    public class ThongKeController : Controller
    {
        Bus_ThongKe bus = new Bus_ThongKe();
        Dto_Tour currentTour;

        List<Dto_ThongKeLoiNhuanTour> dsThongKeLoiNhuanTour = new List<Dto_ThongKeLoiNhuanTour>();

        CultureInfo provider = new CultureInfo("en-US");



        public ActionResult Index(String searchString)
        {
            return View();
        }

        // Thống kê lợi nhuận
        [HttpGet]
        public ActionResult Loinhuan()
        {
            // MM/DD/YYYY
            DateTime dtTuNgayDe = DateTime.Parse("01/01/2021", provider, DateTimeStyles.AdjustToUniversal);
            DateTime dtDenNgayDe = DateTime.Parse("12/12/2021", provider, DateTimeStyles.AdjustToUniversal);
            
            dsThongKeLoiNhuanTour = bus.LayKetQuaThongKeLoiNhuan(1, dtTuNgayDe, dtDenNgayDe);
            
            return View(dsThongKeLoiNhuanTour);
        }

        public ActionResult thongKeLoiNhuan(String tourId, String tuNgay, String denNgay)
        {
            if (string.IsNullOrEmpty(tourId) || string.IsNullOrEmpty(tuNgay) || string.IsNullOrEmpty(denNgay))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin";
                return View(dsThongKeLoiNhuanTour);
            }
            else
            {
                // convert string to Datetime
                DateTime dtTuNgay = DateTime.Parse(tuNgay, provider, DateTimeStyles.AdjustToUniversal);
                DateTime dtDenNgay = DateTime.Parse(denNgay, provider, DateTimeStyles.AdjustToUniversal);


                dsThongKeLoiNhuanTour = bus.LayKetQuaThongKeLoiNhuan(Int16.Parse(tourId), dtTuNgay, dtDenNgay);
                return RedirectToAction("Loinhuan");
            }

        }

        // Thống kê chi phi
        [HttpGet]
        public ActionResult Chiphi()
        {
            return View();
        }

        public ActionResult Chiphi(TourManagement.DTO.Dto_ThongKeChiPhiTour chiPhi)
        {
            return View();

        }

        // Thống kê nhan vien
        [HttpGet]
        public ActionResult Nhanvien()
        {
            return View();
        }

        public ActionResult Nhanvien(TourManagement.DTO.Dto_ThongKePhanCongNV nhanVien)
        {
            return View();

        }

    }
}