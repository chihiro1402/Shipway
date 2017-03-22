using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.DatabaseContext;

namespace ShipwayBusiness.Repository.Repositories
{
    public class ExhibitionStatusRepository : ShipwayRepository<ExhibitionStatus>
    {
        public ExhibitionStatusRepository(ShipwayContext context) : base(context)
        {
        }
    }
}