using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IAgencyProvider
    {
        Agency GetAgencyById(int id);
        List<Agency> GetAllAgency();
        void InsertAgency(Agency agency);
        bool DeleteAgency(Agency agency);
        Agency UpdateAgency(Agency agency);
    }
}
