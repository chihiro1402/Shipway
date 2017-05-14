using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IExhibitionProvider
    {
        Exhibition GetExhibitionById(string id);
        List<Exhibition> GetAllExhibiton();
        void InsertExhibiton(Exhibition exhibiton);
        bool DeleteExhibiton(Exhibition exhibiton);
        List<Exhibition> GetAllExhibitionOfCustomerById(int customerId);
        DateTime GetCreateDate(string exhibitionId);
        Exhibition UpdateExhibition(Exhibition exhibition);

        List<ExhibitionView> GetAllExhibitionView(int customerId);
        List<ExhibitionViewModel> GetAllExhibitionViewModel();
        List<Exhibition> GetAllExhibitionByAssignedShipper(int shipperId);
        List<ExhibitionViewModel> SearchExhibitionByStatus(int exhibitionStatusId);

        ObservableCollection<Exhibition> GetNewExhibition(int shipperId);
        ObservableCollection<Exhibition> GetCompleteExhibition(int shipperId);
        ObservableCollection<Exhibition> GetFailExhibition(int shipperId);
        ObservableCollection<Exhibition> GetWaitSendExhibition(int shipperId);
    }
}
