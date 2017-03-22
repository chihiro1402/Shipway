using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ExhibitionMap: EntityTypeConfiguration<Exhibition>
    {
        public ExhibitionMap()
        {
            ToTable("Exhibition");
            HasKey(p => p.ExhibitionId);
        }
    }
}