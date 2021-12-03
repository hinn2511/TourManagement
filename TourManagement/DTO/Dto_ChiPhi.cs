namespace TourManagement.DTO
{
    public class Dto_ChiPhi
    {
        public int Id { get; set; }
        public int DoanDuLich_Id { get; set; }
        public string TenDoan { get; set; }
        public int LoaiChiPhi_id { get; set; }
        public string TenLoaiChiPhi { get; set; }
        public decimal SoTien { get; set; }
    }
}
