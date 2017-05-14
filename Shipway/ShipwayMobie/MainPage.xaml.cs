using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ShipwayMobie.Resources;
using System.IO.IsolatedStorage;

namespace ShipwayMobie
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var service = new ServiceReference1.ShipwayServiceSoapClient();
            service.ShipperLoginAsync(txtUsername.Text, txtPassword.Password);
            service.ShipperLoginCompleted += Service_ShipperLoginCompleted;
        }

        private void Service_ShipperLoginCompleted(object sender, ServiceReference1.ShipperLoginCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                IsolatedStorageSettings isosetting = IsolatedStorageSettings.ApplicationSettings;
                isosetting["Username"] = txtUsername.Text;
                isosetting["ShipperId"] = e.shipper.ShipperId;
                NavigationService.Navigate(new Uri("/View/Exhibiton/ListExhibition.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
    }
}