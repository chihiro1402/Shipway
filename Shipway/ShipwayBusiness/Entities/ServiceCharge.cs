using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ServiceCharge
    {
        public int ServiceChargeId { get; set; }
        public string Route { get; set; }
        public int KindServiceId { get; set; }
        public int KindTimeReceived { get; set; }
        public int Weigh { get; set; }
        public int CostOderUrban { get; set; }
        public int CostOderSubUrban { get; set; }
        public int AddWeight { get; set; }
        public int AddMoney { get; set; }
    }
}