using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class HistoryTripProvider : IHistoryTripProvider
    {
        public List<HistoryTrip> GetAllHistoryTripByExhibitionId(string exhibitionId)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.HistoryTripRepository.FindAll(p => p.ExhibitionId == exhibitionId).OrderBy(p=>p.DateTrip).ToList();
            }
        }

        public HistoryTrip InsertHistoryTrip(HistoryTrip historyTrip)
        {
            using( var uow=new  ShipwayUnitOfWork())
            {
                return uow.HistoryTripRepository.Add(historyTrip);
            }
        }
    }
}