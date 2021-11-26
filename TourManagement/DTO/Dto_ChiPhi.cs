using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.DTO
{
    public class Dto_ChiPhi
    {
        public int Id { get; set; }
        public int DoanDuLichId  { get; set; }
        public decimal SoTien { get; set; }
        public int LoaiChiPhiId { get; set; }

        public string TenLoaiChiPhi { get; set; }
    }
}
