using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class ExhibitionStatusProvider : IExhibitionStatusProvider
    {
        public List<ExhibitionStatus> GetAllExhibitionStatus()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionStatusRepository.GetAll().ToList();
            }
        }

        public ExhibitionStatus GetExhibitionStatusById(int id)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionStatusRepository.Find(p => p.ExhibitionStatusId == id);
            }
        }

        public int GetIdOfExhibitionStatus(string name)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionStatusRepository.Find(p => p.Name == name)!= null ?uow.ExhibitionStatusRepository.Find(p => p.Name == name).ExhibitionStatusId: -1;
            }
        }
    }
}