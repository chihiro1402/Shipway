using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.DatabaseContext;

namespace ShipwayBusiness.Repository.Repositories
{
    public class RouterRepository : ShipwayRepository<Router>
    {
        public RouterRepository(ShipwayContext context) : base(context)
        {
        }
    }
}