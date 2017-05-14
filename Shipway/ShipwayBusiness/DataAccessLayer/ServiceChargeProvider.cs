using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class ServiceChargeProvider : IServiceChargeProvider
    {
        public bool DeleteServiceCharge(ServiceCharge serviceCharge)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ServiceChargeRepository.Delete(serviceCharge);
            }
        }

        public List<ServiceChargeView> QueryAllServiceChargeView()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                var query = uow.ServiceChargeRepository.Context.ServiceCharge
                    .Join(uow.ServiceChargeRepository.Context.KindService, sc => sc.KindServiceId, ks => ks.KindServiceId, (sc, ks) => new { ServiceCharge = sc, KindService = ks })
                    .Join(uow.ServiceChargeRepository.Context.Router, temp1 => temp1.ServiceCharge.RouterId, router => router.RouterId, (temp1, router) => new { temp1.ServiceCharge, temp1.KindService, Router = router })
                    .Join(uow.ServiceChargeRepository.Context.KindTimeReceived, temp2 => temp2.ServiceCharge.KindTimeReceivedId, ktr => ktr.KindTimeReceivedId, (temp2, ktr) => new { temp2.ServiceCharge, temp2.KindService, temp2.Router, KindTimeReceived = ktr })
                    .Select(p => new ServiceChargeView() {
                        ServiceChargeId = p.ServiceCharge.ServiceChargeId,
                        RouterName= p.Router.RouterName,
                        KindServiceName= p.KindService.KindServiceName,
                        KindTimeReceivedName= p.KindTimeReceived.Name,
                        Weigh= p.ServiceCharge.Weigh,
                        CostOderUrban=p.ServiceCharge.CostOderUrban,
                        CostOderSubUrban=p.ServiceCharge.CostOderSubUrban,
                        AddWeight=p.ServiceCharge.AddWeight,
                        AddMoney=p.ServiceCharge.AddMoney
                }).ToList();
                return query;
            }
        }

        public List<ServiceCharge> GetAllServiceCharge()
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                return uow.ServiceChargeRepository.GetAll().ToList();
            }
        }

        public ServiceCharge GetServiceChargeById(int id)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ServiceChargeRepository.Find(p => p.ServiceChargeId == id);
            }
        }

        public void InsertServiceCharge(ServiceCharge serviceCharge)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                uow.ServiceChargeRepository.Add(serviceCharge);
            }
        }

        public ServiceCharge UpdateServiceCharge(ServiceCharge serviceCharge)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ServiceChargeRepository.Update(serviceCharge);
            }
        }

        public ServiceCharge GetServiceChargeByKindService(int router, int kindService)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ServiceChargeRepository.Find(p => p.RouterId == router && p.KindServiceId == kindService);
            }
        }
    }
}