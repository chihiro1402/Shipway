using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using ShipwayMobie.Helper.Enum;
using System.Collections.ObjectModel;

namespace ShipwayMobie.View.Exhibiton
{
    public partial class ListExhibition : PhoneApplicationPage
    {
        public ListExhibition()
        {
            InitializeComponent();
            IsolatedStorageSettings isolated = IsolatedStorageSettings.ApplicationSettings;
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            if (isolated.Contains("ShipperId"))
            {
                service.GetNewExhibitionAsync(Convert.ToInt32(isolated["ShipperId"]));
                service.GetNewExhibitionCompleted += Service_GetNewExhibitionCompleted;
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            
        }

        private void Service_GetNewExhibitionCompleted(object sender, ServiceReference1.GetNewExhibitionCompletedEventArgs e)
        {
            pivot.DataContext = e.Result;
            total1.Text = "Tổng số đơn hàng : " + e.Result.Count().ToString();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            service.GetDetailexhibitionAsync(txtSearch.Text);
            service.GetDetailexhibitionCompleted += Service_GetDetailexhibitionCompleted;
        }

        private void Service_GetDetailexhibitionCompleted(object sender, ServiceReference1.GetDetailexhibitionCompletedEventArgs e)
        {
            List<ServiceReference1.Exhibition> list = new List<ServiceReference1.Exhibition>();
            list.Add(e.Result);
            ObservableCollection<ServiceReference1.Exhibition> listExhibition = new ObservableCollection<ServiceReference1.Exhibition>(list);
            if (e.Result.ExhibitionStatusId== (int)EnumExhibitionStatus.New)
            {
                pivot.DataContext = listExhibition;
                pivot.SelectedIndex = 0;
                total1.Text = "";
            }
            else if (e.Result.ExhibitionStatusId == (int)EnumExhibitionStatus.Wait)
            {
                pivot.DataContext = listExhibition;
                pivot.SelectedIndex = 1;
                total4.Text = "";
            }
            else if(e.Result.ExhibitionStatusId == (int)EnumExhibitionStatus.Complete)
            {
                pivot.DataContext = listExhibition;
                pivot.SelectedIndex = 2;
                total2.Text = "";
            }
            else if (e.Result.ExhibitionStatusId == (int)EnumExhibitionStatus.Fail)
            {
                pivot.DataContext = listExhibition;
                pivot.SelectedIndex = 3;
                total3.Text = "";
            }
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsolatedStorageSettings isolated = IsolatedStorageSettings.ApplicationSettings;
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            if (pivot.SelectedIndex == 0)
            {
                if (isolated.Contains("ShipperId"))
                {
                    service.GetNewExhibitionAsync(Convert.ToInt32(isolated["ShipperId"]));
                    service.GetNewExhibitionCompleted += Service_GetNewExhibitionCompleted;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            else if (pivot.SelectedIndex==1)
            {
                if (isolated.Contains("ShipperId"))
                {
                    service.GetWaitSendExhibitionAsync(Convert.ToInt32(isolated["ShipperId"]));
                    service.GetWaitSendExhibitionCompleted += Service_GetWaitSendExhibitionCompleted;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            else if (pivot.SelectedIndex == 2)
            {
                if (isolated.Contains("ShipperId"))
                {
                    service.GetCompleteExhibitionAsync(Convert.ToInt32(isolated["ShipperId"]));
                    service.GetCompleteExhibitionCompleted += Service_GetCompleteExhibitionCompleted;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            else if (pivot.SelectedIndex == 3)
            {
                if (isolated.Contains("ShipperId"))
                {
                    service.GetFailExhibitionAsync(Convert.ToInt32(isolated["ShipperId"]));
                    service.GetFailExhibitionCompleted += Service_GetFailExhibitionCompleted;
                }
                else
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
        }

        private void Service_GetWaitSendExhibitionCompleted(object sender, ServiceReference1.GetWaitSendExhibitionCompletedEventArgs e)
        {
            pivot.DataContext = e.Result;
            total4.Text = "Tổng số đơn hàng : " + e.Result.Count().ToString();
        }

        private void Service_GetFailExhibitionCompleted(object sender, ServiceReference1.GetFailExhibitionCompletedEventArgs e)
        {
            pivot.DataContext = e.Result;
            total3.Text = "Tổng số đơn hàng : " + e.Result.Count().ToString();
        }

        private void Service_GetCompleteExhibitionCompleted(object sender, ServiceReference1.GetCompleteExhibitionCompletedEventArgs e)
        {
            pivot.DataContext = e.Result;
            total2.Text = "Tổng số đơn hàng : " + e.Result.Count().ToString();
        }

        private void newexhibition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = newexhibition.SelectedItem as ServiceReference1.Exhibition;
            if (newexhibition.SelectedIndex != -1)
            {
                NavigationService.Navigate(new Uri("/View/Exhibiton/ExhibitionDetail.xaml?ExhibitionId="+item.ExhibitionId, UriKind.Relative));
            }
        }

        private void completeExhibiton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = completeExhibiton.SelectedItem as ServiceReference1.Exhibition;
            if (completeExhibiton.SelectedIndex != -1)
            {
                NavigationService.Navigate(new Uri("/View/Exhibiton/ExhibitionDetail.xaml?ExhibitionId=" + item.ExhibitionId, UriKind.Relative));
            }
        }

        private void failExhibition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = failExhibition.SelectedItem as ServiceReference1.Exhibition;
            if (failExhibition.SelectedIndex != -1)
            {
                NavigationService.Navigate(new Uri("/View/Exhibiton/ExhibitionDetail.xaml?ExhibitionId=" + item.ExhibitionId, UriKind.Relative));
            }
        }

        private void waitsending_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = waitsending.SelectedItem as ServiceReference1.Exhibition;
            if (waitsending.SelectedIndex != -1)
            {
                NavigationService.Navigate(new Uri("/View/Exhibiton/TranformExhibition.xaml?ExhibitionId=" + item.ExhibitionId, UriKind.Relative));
            }
        }
    }
}