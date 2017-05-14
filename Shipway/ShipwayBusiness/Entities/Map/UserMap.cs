using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities.Map
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(p => p.Id);
        }
    }
}