using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ShipperMap: EntityTypeConfiguration<Shipper>
    {
        public ShipperMap()
        {
            ToTable("Shipper");
            HasKey(p => p.ShipperId);
        }
    }
}