using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IServiceChargeProvider
    {
        ServiceCharge GetServiceChargeById(int id);
        List<ServiceCharge> GetAllServiceCharge();
        void InsertServiceCharge(ServiceCharge serviceCharge);
        bool DeleteServiceCharge(ServiceCharge serviceCharge);
        List<ServiceChargeView> QueryAllServiceChargeView();
        ServiceCharge UpdateServiceCharge(ServiceCharge serviceCharge);
        ServiceCharge GetServiceChargeByKindService(int router, int kindService);
    }
}
