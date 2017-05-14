using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class KindTimeReceivedProvider : IKindTimeReceivedProvider
    {
        public List<KindTimeReceived> GetAllKindTimeReceived()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.KindTimeReceivedRepository.GetAll().ToList();
            }
        }

        public KindTimeReceived GetKindTimeReceivedById(int id)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.KindTimeReceivedRepository.Find(p => p.KindTimeReceivedId == id);
            }
        }
    }
}