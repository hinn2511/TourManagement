using System;

namespace TourManagement.DTO
{
    internal class Dto_GiaTour
    {
        public int Id { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TenTour { get; set; }
        public decimal Gia { get; set; }
    }
}
