using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IRouterProvider
    {
        List<Router> GetAllRouter();
        int GetIdRouterByName(string name);
    }
}
