using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class RouterMap: EntityTypeConfiguration<Router>
    {
        public RouterMap()
        {
            ToTable("Router");
            HasKey(p => p.RouterId);
        }
    }
}