using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ProvinceMap:EntityTypeConfiguration<Province>
    {
        public ProvinceMap()
        {
            ToTable("Province");
            HasKey(p => p.ProvinceId);
        }
    }
}