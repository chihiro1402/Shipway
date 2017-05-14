using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class KindTimeReceivedMap: EntityTypeConfiguration<KindTimeReceived>
    {
        public KindTimeReceivedMap()
        {
            ToTable("KindTimeReceived");
            HasKey(p => p.KindTimeReceivedId);
        }
    }
}