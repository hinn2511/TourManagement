using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DTO
{
    public class Dto_PhanCong
    {
        public int NV_Id { get; set; }
        public string HoTen { get; set; }
        public int DoanDuLich_Id { get; set;}
        public string NhiemVu { get; set; }
    }
}
