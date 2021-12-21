using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourManagement;
using TourManagement.DTO;

namespace Web.Models
{
    public class TourDetail
    {
        public Tour tour;

        public GiaTour gia;
        public List<Dto_ThamQuan> dsThamQuan { get; set; }
    }
}