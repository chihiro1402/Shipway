using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;
using System.Collections.ObjectModel;

namespace ShipwayBusiness.DataAccessLayer
{
    public class ExhibitionProvider : IExhibitionProvider
    {
        public bool DeleteExhibiton(Exhibition exhibiton)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.Delete(exhibiton);
            }
        }

        public List<Exhibition> GetAllExhibitionByAssignedShipper(int shipperId)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.FindAll(p => p.AssignShipperId == shipperId).ToList();
            }
        }

        public List<Exhibition> GetAllExhibitionOfCustomerById(int customerId)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.FindAll(p => p.CreatedUserId == customerId).ToList();
            }
        }

        public List<ExhibitionView> GetAllExhibitionView(int customerId)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                var result = uow.ExhibitionRepositoty.Context.Exhibition.
                    Join(uow.ExhibitionRepositoty.Context.ExhibitionStatus, ex => ex.ExhibitionStatusId, es => es.ExhibitionStatusId, (ex, es) => new { Exhibition = ex, ExhibitionStatus = es })
                    .Where(p=>p.Exhibition.CreatedUserId==customerId)
                    .Select(p => new ExhibitionView()
                    {
                        ExhibitionId= p.Exhibition.ExhibitionId,
                        ReceiverName=p.Exhibition.ReceiverName,
                        ReceiverAddress=p.Exhibition.ReceiverAddress,
                        ReceiverPhoneNumber=p.Exhibition.ReceiverPhoneNumber,
                        Cost=p.Exhibition.Cost,
                        CreatedDate=p.Exhibition.CreatedDate,
                        ExhibitionStatus=p.ExhibitionStatus.Name
                    }).ToList();
                return result;
            }
        }

        public List<Exhibition> GetAllExhibiton()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.GetAll().ToList();
            }
        }

        public DateTime GetCreateDate(string exhibitionId)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.Find(p => p.ExhibitionId == exhibitionId).CreatedDate;
            }
        }

        public Exhibition GetExhibitionById(string id)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.Find(p => p.ExhibitionId == id);
            }
        }

        public ObservableCollection<Exhibition> GetFailExhibition(int shipperId)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                var exhibitionStatusId = uow.ExhibitionStatusRepository.Find(e => e.Name == "Giao thất bại").ExhibitionStatusId;
                var list= uow.ExhibitionRepositoty.FindAll(p => p.AssignShipperId == shipperId && p.ExhibitionStatusId == exhibitionStatusId).ToList();
                ObservableCollection<Exhibition> listExhibiton = new ObservableCollection<Exhibition>(list);
                return listExhibiton;
            }
        }

        public ObservableCollection<Exhibition> GetCompleteExhibition(int shipperId)
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                var exhibitionStatusId = uow.ExhibitionStatusRepository.Find(e => e.Name == "Giao thành công").ExhibitionStatusId;
                var list = uow.ExhibitionRepositoty.FindAll(p => p.AssignShipperId == shipperId && p.ExhibitionStatusId == exhibitionStatusId).ToList();
                ObservableCollection<Exhibition> listExhibiton = new ObservableCollection<Exhibition>(list);
                return listExhibiton;
            }
        }

        public ObservableCollection<Exhibition> GetNewExhibition(int shipperId)
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                var exhibitionStatusId = uow.ExhibitionStatusRepository.Find(e => e.Name == "Mới tạo").ExhibitionStatusId;
                var list = uow.ExhibitionRepositoty.FindAll(p => p.AssignShipperId == shipperId && p.ExhibitionStatusId == exhibitionStatusId).ToList();
                ObservableCollection<Exhibition> listExhibiton = new ObservableCollection<Exhibition>(list);
                return listExhibiton;
            }
        }

        public void InsertExhibiton(Exhibition exhibiton)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                uow.ExhibitionRepositoty.Add(exhibiton);
            }
        }

        public Exhibition UpdateExhibition(Exhibition exhibition)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.ExhibitionRepositoty.Update(exhibition);
            }
        }

        public ObservableCollection<Exhibition> GetWaitSendExhibition(int shipperId)
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                var exhibitionStatusId = uow.ExhibitionStatusRepository.Find(e => e.Name == "Đã nhận").ExhibitionStatusId;
                var list = uow.ExhibitionRepositoty.FindAll(p => p.AssignShipperId == shipperId && p.ExhibitionStatusId == exhibitionStatusId).ToList();
                ObservableCollection<Exhibition> listExhibiton = new ObservableCollection<Exhibition>(list);
                return listExhibiton;
            }
        }

        public List<ExhibitionViewModel> GetAllExhibitionViewModel()
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                var result = uow.ExhibitionRepositoty.Context.Exhibition.
                    Join(uow.ExhibitionRepositoty.Context.ExhibitionStatus, ex => ex.ExhibitionStatusId, es => es.ExhibitionStatusId, (ex, es) => new { Exhibition = ex, ExhibitionStatus = es })
                    .Select(p => new ExhibitionViewModel()
                    {
                        Exhibition= p.Exhibition,
                        ExhibitonStatus=p.ExhibitionStatus.Name
                    }).ToList();
                return result;
            }
        }

        public List<ExhibitionViewModel> SearchExhibitionByStatus(int exhibitionStatusId)
        {
            using (var uow = new ShipwayUnitOfWork())
            {
                var result = uow.ExhibitionRepositoty.Context.Exhibition.
                    Join(uow.ExhibitionRepositoty.Context.ExhibitionStatus, ex => ex.ExhibitionStatusId, es => es.ExhibitionStatusId, (ex, es) => new { Exhibition = ex, ExhibitionStatus = es })
                    .Where(p=>p.Exhibition.ExhibitionStatusId== exhibitionStatusId)
                    .Select(p => new ExhibitionViewModel()
                    {
                        Exhibition = p.Exhibition,
                        ExhibitonStatus = p.ExhibitionStatus.Name
                    }).ToList();
                return result;
            }
        }
    }
}