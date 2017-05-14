using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class AgencyProvider : IAgencyProvider
    {
        public bool DeleteAgency(Agency agency)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.AgencyRepository.Delete(agency);
            }
        }

        public Agency GetAgencyById(int id)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.AgencyRepository.Find(p => p.AgencyId == id);
            }
        }

        public List<Agency> GetAllAgency()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.AgencyRepository.GetAll().ToList();
            }
        }

        public void InsertAgency(Agency agency)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                uow.AgencyRepository.Add(agency);
            }
        }

        public Agency UpdateAgency(Agency agency)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.AgencyRepository.Update(agency);
            }
        }
    }
}