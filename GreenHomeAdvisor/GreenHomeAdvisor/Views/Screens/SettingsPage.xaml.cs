using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GreenHomeAdvisor.Entity;

namespace GreenHomeAdvisor.Views.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        Settings settings;
        User currentUser;

        SwitchCell switchCell1;
        SwitchCell switchCell2;

        public SettingsPage()
        {
            InitializeComponent();
            LoadSettings();

            Title = "Settings";
        }

        private void LoadSettings()
        {
            settings = App.SettingsDatabase.GetSettings();
            //currentUser = App.UserDatabase.getUser();

            TableView table;

            switchCell1 = new SwitchCell
            {
                Text = "SwitchCell 1",
                On = settings.switch1
            };

            switchCell1.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                switchCell1Switched(sender, e);
            };

            switchCell2 = new SwitchCell
            {
                Text = "SwitchCell 2",
                On = settings.switch2
            };

            switchCell2.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                switchCell2Switched(sender, e);
            };

            table = new TableView
            {
                Root = new TableRoot
                {
                    new TableSection
                    {
                        switchCell1,
                        switchCell2
                    }
                }
            };

            table.VerticalOptions = LayoutOptions.FillAndExpand;

            MainLayout.Children.Add(table);
        }

        private void switchCell1Switched(object sender, ToggledEventArgs e)
        {
            settings.switch1 = e.Value;
        }

        private void switchCell2Switched(object sender, ToggledEventArgs e)
        {
            settings.switch2 = e.Value;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var action = await DisplayAlert("Settings", "Do you want to save the settings?", "Yes", "Cancel");
            if(action)
            {
                SaveSettings();
            }
        }

        private void SaveSettings()
        {
            App.SettingsDatabase.SaveSettings(settings);
        }

    }
}
