using System;

namespace TourManagement.DTO
{
    public class Dto_DoanDuLich
    {
        public int Id { get; set; }
        public string TenTour { get; set; }
        public string TenDoan { get; set; }
        public int Tour_Id { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal ChiPhi { get; set; }
    }
}
