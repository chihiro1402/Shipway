using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class NoteRequiredProvider : INoteRequiredProvider
    {
        public List<NoteRequired> GetAllNoteRequired()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.NoteRequiredRepository.GetAll().ToList();
            }
        }

        public NoteRequired GetNoteRequiredById(int id)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.NoteRequiredRepository.Find(p => p.NoteRequiredId == id);
            }
        }
    }
}