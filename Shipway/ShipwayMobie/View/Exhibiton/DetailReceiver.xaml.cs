using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Services;

namespace ShipwayMobie.View.Exhibiton
{
    public partial class DetailReceiver : PhoneApplicationPage
    {
        public DetailReceiver()
        {
            InitializeComponent();
        }

        string id;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            id = NavigationContext.QueryString["ExhibitionId"].ToString();
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            service.GetDetailexhibitionAsync(id);
            service.GetDetailexhibitionCompleted += Service_GetDetailexhibitionCompleted;
            exhibitionId.Text= id;
        }

        private void Service_GetDetailexhibitionCompleted(object sender, ServiceReference1.GetDetailexhibitionCompletedEventArgs e)
        {
            this.DataContext = e.Result;
        }

        private void fail_Click(object sender, RoutedEventArgs e)
        {
            myIndeterminateProbar.IsIndeterminate = true;
            GetCurrentCoordinate2();
        }

        private void Success_Click(object sender, RoutedEventArgs e)
        {
            myIndeterminateProbar.IsIndeterminate = true;
            GetCurrentCoordinate1();
        }

        private async void GetCurrentCoordinate1()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition position = await locator.GetGeopositionAsync();
            GeoCoordinate coordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            query.GeoCoordinate = coordinate;
            query.QueryAsync();
            query.QueryCompleted += Query_QueryCompleted1;
        }

        private void Query_QueryCompleted1(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            try
            {
                string text = "";
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

                    text= addressString1 + addressString2 + addressString3;
                }

                var service = new ServiceReference1.ShipwayServiceSoapClient();
                service.UpdateStatusOfExhibitionAsync(exhibitionId.Text, "Giao thành công", text);
                service.UpdateStatusOfExhibitionCompleted += Service_UpdateStatusOfExhibitionCompleted;
            }
            catch
            {

            }
        }

        private void Service_UpdateStatusOfExhibitionCompleted(object sender, ServiceReference1.UpdateStatusOfExhibitionCompletedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Exhibiton/ExhibitionComplete.xaml?ExhibitionId=" + exhibitionId.Text, UriKind.Relative));
        }

        private async void GetCurrentCoordinate2()
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracy = PositionAccuracy.High;
            Geoposition position = await locator.GetGeopositionAsync();
            GeoCoordinate coordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            ReverseGeocodeQuery query = new ReverseGeocodeQuery();
            query.GeoCoordinate = coordinate;
            query.QueryAsync();
            query.QueryCompleted += Query_QueryCompleted2;
        }

        private void Query_QueryCompleted2(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            try
            {
                string text = "";
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

                    text = addressString1 + addressString2 + addressString3;
                }

                var service = new ServiceReference1.ShipwayServiceSoapClient();
                service.UpdateStatusOfExhibitionAsync(exhibitionId.Text, "Giao thất bại", text);
                service.UpdateStatusOfExhibitionCompleted += Service_UpdateStatusOfExhibitionCompleted;
            }
            catch
            {

            }
        }
    }
}