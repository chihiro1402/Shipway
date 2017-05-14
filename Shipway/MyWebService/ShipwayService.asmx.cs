using ShipwayBusiness.CoreProvider;
using ShipwayBusiness.DataAccessLayer;
using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyWebService
{
    /// <summary>
    /// Summary description for ShipwayService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ShipwayService : System.Web.Services.WebService
    {
        private IShipperProvider shipperProvider;
        private IExhibitionProvider exhibitionProvider;
        private IExhibitionStatusProvider exhibitionStatusProvider;
        private HistoryTripProvider historyTripProvider;
        public ShipwayService()
        {
            shipperProvider = new ShipperProvider();
            exhibitionProvider = new ExhibitionProvider();
            exhibitionStatusProvider = new ExhibitionStatusProvider();
            historyTripProvider = new HistoryTripProvider();
        }

        [WebMethod]
        public bool ShipperLogin(string username, string password, out Shipper shipper)
        {
            var passwordHash = ShipwayBusiness.Helper.Utils.MD5(password);
            var existShipper = shipperProvider.GetShipperByUsernameAndPassword(username, passwordHash);
            if (existShipper != null)
            {
                shipper = existShipper;
                return true;
            }
            else
            {
                shipper = null;
                return false;
            }
        }

        [WebMethod]
        public List<Exhibition> GetListExhibitionAssignedForShipper(int shipperId)
        {
            var list = exhibitionProvider.GetAllExhibitionByAssignedShipper(shipperId);
            return list;
        }

        [WebMethod]
        public Exhibition GetDetailexhibition(string id)
        {
            return exhibitionProvider.GetExhibitionById(id);
        }

        [WebMethod]
        public bool UpdateStatusOfExhibition(string exhibitionId, string exhibitionStatus, string address)
        {
            var exhibition = exhibitionProvider.GetExhibitionById(exhibitionId);
            int exhibitionStatusId = exhibitionStatusProvider.GetIdOfExhibitionStatus(exhibitionStatus);
            exhibition.ExhibitionStatusId = exhibitionStatusId;
            var exhibitionUpdate = exhibitionProvider.UpdateExhibition(exhibition);
            HistoryTrip historyTrip = new HistoryTrip();
            historyTrip.ExhibitionId = exhibitionUpdate.ExhibitionId;
            historyTrip.ExhibitionStatusId = exhibitionUpdate.ExhibitionStatusId;
            historyTrip.CurrentAddress = address;
            historyTrip.DateTrip = DateTime.Now;
            var historyNew=historyTripProvider.InsertHistoryTrip(historyTrip);
            if(exhibitionUpdate!=null && historyNew != null)
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public List<ExhibitionStatus> GetAllExhibitionStatus()
        {
            return exhibitionStatusProvider.GetAllExhibitionStatus();
        }

        [WebMethod]
        public ExhibitionStatus GetExhibitionStatus(int id)
        {
            return exhibitionStatusProvider.GetExhibitionStatusById(id);
        }

        [WebMethod]
        public ObservableCollection<Exhibition> GetNewExhibition(int shipperId)
        {
            return exhibitionProvider.GetNewExhibition(shipperId);
        }

        [WebMethod]
        public ObservableCollection<Exhibition> GetCompleteExhibition(int shipperId)
        {
            return exhibitionProvider.GetCompleteExhibition(shipperId);
        }

        [WebMethod]
        public ObservableCollection<Exhibition> GetFailExhibition(int shipperId)
        {
            return exhibitionProvider.GetFailExhibition(shipperId);
        }

        [WebMethod]
        public ObservableCollection<Exhibition> GetWaitSendExhibition(int shipperId)
        {
            return exhibitionProvider.GetWaitSendExhibition(shipperId);
        }
    }
}
