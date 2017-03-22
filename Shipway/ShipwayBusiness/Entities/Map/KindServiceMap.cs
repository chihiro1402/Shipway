using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class KindServiceMap: EntityTypeConfiguration<KindService>
    {
        public KindServiceMap()
        {
            ToTable("KindService");
            HasKey(p => p.KindServiceId);
        }
    }
}