using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class ServiceCharge
    {
        public int ServiceChargeId { get; set; }
        public int RouterId { get; set; }
        public int KindServiceId { get; set; }
        public int KindTimeReceivedId { get; set; }
        public decimal Weigh { get; set; }
        public int CostOderUrban { get; set; }
        public int CostOderSubUrban { get; set; }
        public decimal AddWeight { get; set; }
        public int AddMoney { get; set; }
    }

    public class ServiceChargeView
    {
        public int ServiceChargeId { get; set; }
        public string  RouterName { get; set; }
        public string KindServiceName { get; set; }
        public string KindTimeReceivedName { get; set; }
        public decimal Weigh { get; set; }
        public int CostOderUrban { get; set; }
        public int CostOderSubUrban { get; set; }
        public decimal AddWeight { get; set; }
        public int AddMoney { get; set; }
    }
}