using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class Province
    {
        public string ProvinceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Region { get; set; }
    }
}