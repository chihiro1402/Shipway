using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class ExhibitionStatusMap:EntityTypeConfiguration<ExhibitionStatus>
    {
        public ExhibitionStatusMap()
        {
            ToTable("ExhibitionStatus");
            HasKey(p => p.ExhibitionStatusId);
        }
    }
}