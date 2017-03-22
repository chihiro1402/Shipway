using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ServiceChargeMap: EntityTypeConfiguration<ServiceCharge>
    {
        public ServiceChargeMap()
        {
            ToTable("ServiceCharge");
            HasKey(p => p.ServiceChargeId);
        }
    }
}