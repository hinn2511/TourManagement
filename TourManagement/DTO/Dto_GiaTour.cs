using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DTO
{
    public class Dto_GiaTour
    {
        public int Id { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal Gia { get; set; }
        public bool DangApDung { get; set; }
        public int Tour_Id { get; set; }
    }
}
