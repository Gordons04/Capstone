using GreenHomeAdvisor.Database;
using GreenHomeAdvisor.Models;
using GreenHomeAdvisor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHomeAdvisor
{
    public class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static SettingsDatabaseController settingsDatabase;



        public App()    //Set Login Page as start
        {
            MainPage = new LoginPage();
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public static SettingsDatabaseController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                {
                    settingsDatabase = new SettingsDatabaseController();
                }
                return settingsDatabase;
            }
        }

        //Internet Connection Functions Below
        public static bool CheckInternetConnection()
        {
            var networkConnection = DependencyService.Get<initNetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                return false;
            }
            return true;
        }

    }
}
