using GreenHomeAdvisor.Models;
using GreenHomeAdvisor.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHomeAdvisor.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Homepage", Constants.buttonBackgroundColor, typeof(HomePage)));
            items.Add(new MasterMenuItem("Energy Statistics", Constants.buttonBackgroundColor, typeof(StatisticsPage)));
            items.Add(new MasterMenuItem("Settings", Constants.buttonBackgroundColor, typeof(SettingsPage)));
            ListView.ItemsSource = items;
        }

        private async void LogoutButtonClicked(object sender, EventArgs e)
        {

            if (Device.OS == TargetPlatform.Android)                    //Partial Logout Functionality
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}
