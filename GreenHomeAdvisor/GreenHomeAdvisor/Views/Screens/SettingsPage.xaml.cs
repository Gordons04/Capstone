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

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void LoadSettings()
        {
            settings = App.SettingsDatabase.GetSettings();
            //currentUser = App.UserDatabase.getUser();

            TableView table;

            switchCell1 = new SwitchCell            //Setup first switch button in settings
            {
                Text = "SwitchCell 1",
                On = settings.switch1
            };

            switchCell1.OnChanged += (object sender, ToggledEventArgs e) =>     //Causes an event to occur when value changes
            {
                switchCell1Switched(sender, e);
            };

            switchCell2 = new SwitchCell            //Setup second switch buton in settings
            {
                Text = "SwitchCell 2",
                On = settings.switch2
            };

            switchCell2.OnChanged += (object sender, ToggledEventArgs e) =>     //Causes an event to occur when value changes
            {
                switchCell2Switched(sender, e);
            };

            table = new TableView           //Setup the table which holds the settings
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

            MainLayout.Children.Add(table);             //Adds the table to the frontend under the mainlayout section
        }

        private void switchCell1Switched(object sender, ToggledEventArgs e)     //Changes the value of switch1 in the settings entity
        {
            settings.switch1 = e.Value;
        }

        private void switchCell2Switched(object sender, ToggledEventArgs e)     //Changes the value of switch2 in the settings entity
        {
            settings.switch2 = e.Value;
        }

        protected override async void OnDisappearing()      //Handles saving the settings after leaving the settings screen
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
