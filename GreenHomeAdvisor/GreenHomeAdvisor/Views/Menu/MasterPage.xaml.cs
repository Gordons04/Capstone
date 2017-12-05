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
            items.Add(new MasterMenuItem("Energy Statistics", Constants.buttonBackgroundColor, typeof(StatisticsPage)));
            items.Add(new MasterMenuItem("Settings", Constants.buttonBackgroundColor, typeof(SettingsPage)));
            ListView.ItemsSource = items;
        }

        //async void OnLogoutClicked(object sender, EventArgs e)
        //{
            
        //}
    }
}
