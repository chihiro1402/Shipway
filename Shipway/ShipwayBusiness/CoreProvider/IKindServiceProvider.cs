using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IKindServiceProvider
    {
        KindService GetKindServiceById(int id);
        List<KindService> GetAllKindService();
    }
}
