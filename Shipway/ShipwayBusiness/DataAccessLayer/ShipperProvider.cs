using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class ShipperProvider : IShipperProvider
    {
        public bool DeleteShipper(Shipper shipper)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ShipperRepository.Delete(shipper);
            }
        }

        public List<Shipper> GetAllShipper()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ShipperRepository.GetAll().ToList();
            }
        }

        public Shipper GetShipperById(int id)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ShipperRepository.Find(p => p.ShipperId == id);
            }
        }

        public Shipper GetShipperByUsernameAndPassword(string username, string password)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ShipperRepository.Find(p => p.Username == username && p.Password == password);
            }
        }

        public void InsertShipper(Shipper shipper)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                uow.ShipperRepository.Add(shipper);
            }
        }

        public Shipper UpdateShipper(Shipper shipper)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ShipperRepository.Update(shipper);
            }
        }
    }
}