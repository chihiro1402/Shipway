using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.DatabaseContext;

namespace ShipwayBusiness.Repository.Repositories
{
    public class DistrictRepository : ShipwayRepository<District>
    {
        public DistrictRepository(ShipwayContext context) : base(context)
        {
        }
    }
}