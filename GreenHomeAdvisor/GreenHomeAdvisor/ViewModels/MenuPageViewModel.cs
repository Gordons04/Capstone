using GreenHomeAdvisor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GreenHomeAdvisor.ViewModels
{
    public class MenuPageViewModel
    {

        public ICommand GoSettingsCommand { get; set; }
        public ICommand GoHomeViewCommand { get; set; }

        public MenuPageViewModel()  //Menu Page Constructor
        {
            GoSettingsCommand = new Command(GoSettings);
            GoHomeViewCommand = new Command(GoHomeView);
        }

        public void SetPage(Page page)  //Sets the passed page as the navigation page
        {
            App.RootPage.Detail = new NavigationPage(page);
        }

        void GoSettings(object obj)
        {
            SetPage(new SettingsPage());
        }

        void GoHomeView(object obj)
        {
            SetPage(new HomeViewPage());
        }

    }
}
