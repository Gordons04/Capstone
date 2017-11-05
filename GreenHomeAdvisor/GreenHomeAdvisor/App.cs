using GreenHomeAdvisor.ViewModels;
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
        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Color BankBlue = Color.FromHex("#127ac7");


        static string AppName = "GreenHomeAdvisor";

        Entry usernameEntry = new Entry();
        Entry passwordEntry = new Entry();
        Label messageLabel = new Label();
        ActivityIndicator loadingWheel = new ActivityIndicator();

        // *********************************************************************
        // TODO: wrap in a global Navigation Service (for example purposes only)
        // https://wolfprogrammer.com/2016/07/22/navigation-using-mvvm-light/
        public static NavigationPage NavigationPage { get; private set; }
        public static MainPage RootPage;

        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;    //provide access to the value a variable holds
            }
            set
            {
                RootPage.IsPresented = value; // assign values to the variables of the objects
            }
        }
        // *********************************************************************


        public App()    // contains login button password field

        {
            messageLabel.TextColor = Color.Red;
            passwordEntry.IsPassword = true;

            var loginButton = new Button
            {
                Text = "Login",
            };

            loginButton.BackgroundColor = Color.Green;
            loginButton.TextColor = Color.White;

            loginButton.Clicked += OnLoginButtonClicked;
            //var logo = new Image { Aspect = Aspect.AspectFit };
            //logo.Source = ImageSource.FromFile("logo.jpg");

            // Set up the loading wheel
            loadingWheel.Color = Color.Green;
            loadingWheel.IsRunning = true;
            loadingWheel.IsVisible = false;

            // The root page of your application
            var content = new ContentPage
            {

                Title = "Login",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Padding = new Thickness(40, 0, 40, 0),
                    Children = {
                        //logo,
                            new Label { Text = "Sign In", TextColor=Color.Green, FontAttributes= FontAttributes.Bold, FontSize=18, Margin = new Thickness(0,80,0,20) },
                            new Label { Text = "Username" },
                            usernameEntry,
                            new Label { Text = "Password" },
                            passwordEntry,
                            loadingWheel,
                            loginButton,
                            messageLabel
                    }
                }
            };

            MainPage = content;
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var content = string.Empty;

            //Display Loading Wheel
            loadingWheel.IsVisible = true;

            content = passwordEntry.Text;

            if(content.ToLower() != "password")
            {
                // Hide loading wheel
                loadingWheel.IsVisible = false;

                messageLabel.Text = "Username or password incorrect. Please try again.";
                passwordEntry.Text = string.Empty;
            }
            else
            {
                var menuPage = new MenuPage();
                NavigationPage = new NavigationPage(new HomeViewPage());
                RootPage = new Views.MainPage();
                RootPage.Master = menuPage;
                RootPage.Detail = NavigationPage;
                MainPage = RootPage;
            }

            
        }

    }
}
