using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Services;

namespace ShipwayMobie.View.Exhibiton
{
    public partial class TranformExhibition : PhoneApplicationPage
    {
        public TranformExhibition()
        {
            InitializeComponent();
        }

        string exhibitionId;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            exhibitionId = NavigationContext.QueryString["ExhibitionId"].ToString();
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            service.GetDetailexhibitionAsync(exhibitionId);
            service.GetDetailexhibitionCompleted += Service_GetDetailexhibitionCompleted;
            ExhibitionId.Text = exhibitionId;
        }

        private void Service_GetDetailexhibitionCompleted(object sender, ServiceReference1.GetDetailexhibitionCompletedEventArgs e)
        {
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            this.DataContext = e.Result;
            service.GetExhibitionStatusAsync(e.Result.ExhibitionStatusId);
            service.GetExhibitionStatusCompleted += Service_GetExhibitionStatusCompleted;
        }

        private void Service_GetExhibitionStatusCompleted(object sender, ServiceReference1.GetExhibitionStatusCompletedEventArgs e)
        {
            txtExhibitionStatus.Text = e.Result.Name;
        }

        private async void btnDirection_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/View/Exhibiton/Direction.xaml?start=" + senderAddress.Text+"&end="+receiveAddress.Text, UriKind.Relative));
            MapsDirectionsTask mapsDic = new MapsDirectionsTask();
            LabeledMapLocation start = new LabeledMapLocation();
            start.Label = senderAddress.Text;
            LabeledMapLocation end = new LabeledMapLocation();
            end.Label = receiveAddress.Text;
            mapsDic.Start = start; // điểm bắt đầu
            mapsDic.End = end; // điểm kết thúc
            mapsDic.Show();
        }

        private async void GetCurrentCoordinate()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition position = await locator.GetGeopositionAsync();
            GeoCoordinate coordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            query.GeoCoordinate = coordinate;
            query.QueryAsync();
            query.QueryCompleted += Query_QueryCompleted;
        }

        private void Query_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            try
            {
                if (e.Cancelled)
                {

                }
                else if (e.Result != null)
                {
                    MapAddress mapaddress = e.Result[0].Information.Address;
                    string addressString1 = mapaddress.HouseNumber + " " + mapaddress.Street;
                    string addressString2 = mapaddress.District + ", " + mapaddress.City;
                    string addressString3 = mapaddress.Country;
                    if (addressString1 != " ")
                        addressString1 = addressString1 + "\n";
                    else
                        addressString1 = "";

                    if (addressString2 != ",  ")
                        addressString2 = addressString2 + "\n";
                    else
                        addressString2 = "";

                    txtAddress.Text = addressString1 + addressString2 + addressString3;
                }

                var service = new ServiceReference1.ShipwayServiceSoapClient();
                service.UpdateStatusOfExhibitionAsync(ExhibitionId.Text, "Đã nhận", txtAddress.Text);
                service.UpdateStatusOfExhibitionCompleted += Service_UpdateStatusOfExhibitionCompleted;
            }
            catch
            {

            }
        }

        private void Service_UpdateStatusOfExhibitionCompleted(object sender, ServiceReference1.UpdateStatusOfExhibitionCompletedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Exhibiton/DetailReceiver.xaml?ExhibitionId=" + ExhibitionId.Text, UriKind.Relative));
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetCurrentCoordinate();
            }
            catch
            {

            }
        }
    }
}