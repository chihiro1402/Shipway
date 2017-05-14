using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IShipperProvider
    {
        Shipper GetShipperById(int id);
        List<Shipper> GetAllShipper();
        void InsertShipper(Shipper shipper);
        bool DeleteShipper(Shipper shipper);
        Shipper UpdateShipper(Shipper shipper);

        Shipper GetShipperByUsernameAndPassword(string username, string password);
    }
}
