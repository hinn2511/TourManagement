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
        List<Dto_ThongKeChiPhiTour> dsThongKeChiPhiTour = new List<Dto_ThongKeChiPhiTour>();
        List<Dto_ThongKePhanCongNV> dsThongKePhanCongNV = new List<Dto_ThongKePhanCongNV>();


        CultureInfo provider = new CultureInfo("en-US");

        DateTime dtTuNgay;
        DateTime dtDenNgay;


        public ActionResult Index(String searchString)
        {
           
            return View();
        }

        // Thống kê lợi nhuận
        [HttpGet]
        public ActionResult Loinhuan(String tourId, String tuNgay, String denNgay)
        {
            ViewBag.dsTour = bus.LayDanhSachTour();
            if (tourId != null && tuNgay != null && denNgay != null)
            {
                    dtTuNgay = DateTime.Parse(tuNgay, provider, DateTimeStyles.AdjustToUniversal);
                    dtDenNgay = DateTime.Parse(denNgay, provider, DateTimeStyles.AdjustToUniversal);
                    if (dtTuNgay < dtDenNgay)
                    {
                        var dsThongKe = bus.LayKetQuaThongKeLoiNhuan(Int16.Parse(tourId), dtTuNgay, dtDenNgay);
                        return View(dsThongKe);
                    }
                    else
                    {
                        ViewBag.Error = "Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc!";
                    }
            }
            return View();
        }


        // Thống kê chi phi
        [HttpGet]
        public ActionResult Chiphi(String tourId, String tuNgay, String denNgay)
        {
            ViewBag.dsTour = bus.LayDanhSachTour();
            if (tourId != null && tuNgay != null && denNgay != null)
            {
                dtTuNgay = DateTime.Parse(tuNgay, provider, DateTimeStyles.AdjustToUniversal);
                dtDenNgay = DateTime.Parse(denNgay, provider, DateTimeStyles.AdjustToUniversal);
                if (dtTuNgay < dtDenNgay)
                {
                    var dsThongKe = bus.LayKetQuaThongKeChiPhi(Int16.Parse(tourId), dtTuNgay, dtDenNgay);
                    return View(dsThongKe);
                }
                else
                {
                    ViewBag.Error = "Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc!";
                }
            }
            return View();

        }

       

        // Thống kê nhan vien
        [HttpGet]
        public ActionResult Nhanvien(String nvId, String tuNgay, String denNgay)
        {
            ViewBag.dsNV = bus.LayDanhSachNhanVien();
            if (nvId != null && tuNgay != null && denNgay != null)
            {
                dtTuNgay = DateTime.Parse(tuNgay, provider, DateTimeStyles.AdjustToUniversal);
                dtDenNgay = DateTime.Parse(denNgay, provider, DateTimeStyles.AdjustToUniversal);
                if (dtTuNgay < dtDenNgay)
                {
                    var dsThongKe = bus.LayKetQuaThongKeNhanVien(Int16.Parse(nvId), dtTuNgay, dtDenNgay);
                    return View(dsThongKe);
                }
                else
                {
                    ViewBag.Error = "Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc!";
                }

            }
            return View();
        }

       

    }
}