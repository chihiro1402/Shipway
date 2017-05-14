using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class HistoryTripMap: EntityTypeConfiguration<HistoryTrip>
    {
        public HistoryTripMap()
        {
            ToTable("HistoryTrip");
            HasKey(p => p.HistoryTripId);
        }
    }
}