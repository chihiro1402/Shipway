using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IKindTimeReceivedProvider
    {
        KindTimeReceived GetKindTimeReceivedById(int id);
        List<KindTimeReceived> GetAllKindTimeReceived();
    }
}
