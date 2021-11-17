using System.Collections.Generic;
using System.Linq;

namespace TourManagement.DAL
{
    public class Dto_LoaiTour
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
    }

    public class Dal_LoaiTour
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<LoaiTour> getAllTourType()
        {
            List<LoaiTour> types = context.LoaiTours.Select(lt => lt).ToList();
            return types;
        }
    }
}
