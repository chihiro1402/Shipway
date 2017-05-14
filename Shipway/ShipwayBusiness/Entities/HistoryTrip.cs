using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class HistoryTrip
    {
        public int HistoryTripId { get; set; }
        public string ExhibitionId { get; set; }
        public DateTime? DateTrip { get; set; }
        public int? ExhibitionStatusId { get; set; }
        public string CurrentAddress { get; set; }
    }
}