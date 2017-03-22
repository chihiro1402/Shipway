using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class AgencyMap: EntityTypeConfiguration<Agency>
    {
        public AgencyMap()
        {
            ToTable("Agency");
            HasKey(p => p.AgencyId);
        }
    }
}