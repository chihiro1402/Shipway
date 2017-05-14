using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class RouterProvider : IRouterProvider
    {
        public List<Router> GetAllRouter()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.RouterRepository.GetAll().ToList();
            }
        }

        public int GetIdRouterByName(string name)
        {
            using (var uow= new ShipwayUnitOfWork())
            {
                return uow.RouterRepository.Find(p => p.RouterName == name)!= null? uow.RouterRepository.Find(p => p.RouterName == name).RouterId: -1;
            }
        }
    }
}