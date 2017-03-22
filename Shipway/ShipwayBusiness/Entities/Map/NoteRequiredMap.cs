using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class NoteRequiredMap: EntityTypeConfiguration<NoteRequired>
    {
        public NoteRequiredMap()
        {
            ToTable("NoteRequired");
            HasKey(p => p.NoteRequiredId);
        }
    }
}