using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class WardMap: EntityTypeConfiguration<Ward>
    {
        public WardMap()
        {
            ToTable("Ward");
            HasKey(p => p.WardId);
        }
    }
}