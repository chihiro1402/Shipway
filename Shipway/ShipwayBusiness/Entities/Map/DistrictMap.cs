using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class DistrictMap:EntityTypeConfiguration<District>
    {
        public DistrictMap()
        {
            ToTable("District");
            HasKey(p => p.DistrictId);
        }
    }
}