using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class KindServiceProvider : IKindServiceProvider
    {
        public List<KindService> GetAllKindService()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.KindServiceRepository.GetAll().ToList();
            }
        }

        public KindService GetKindServiceById(int id)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.KindServiceRepository.Find(p => p.KindServiceId == id);
            }
        }
    }
}