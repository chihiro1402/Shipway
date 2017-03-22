using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class Agency
    {
        public int AgencyId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AgencyName { get; set; }
        public string ActivityTime { get; set; }
    }
}