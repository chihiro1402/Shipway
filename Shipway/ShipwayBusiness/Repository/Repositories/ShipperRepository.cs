using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.DatabaseContext;

namespace ShipwayBusiness.Repository.Repositories
{
    public class ShipperRepository : ShipwayRepository<Shipper>
    {
        public ShipperRepository(ShipwayContext context) : base(context)
        {
        }
    }
}