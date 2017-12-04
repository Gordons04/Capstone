using GreenHomeAdvisor.Database;
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
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;

        //public static int ScreenWidth;
        //public static int ScreenHeight;


        //static string AppName = "GreenHomeAdvisor";

        //Entry usernameEntry = new Entry();
        //Entry passwordEntry = new Entry();
        //Label messageLabel = new Label();
        //ActivityIndicator loadingWheel = new ActivityIndicator();

        // *********************************************************************
        // TODO: wrap in a global Navigation Service (for example purposes only)
        // https://wolfprogrammer.com/2016/07/22/navigation-using-mvvm-light/
        public static NavigationPage NavigationPage { get; set; }
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


        public static UserDatabaseController userDatabase()
        {
            get{
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
            }
        }


        public App()    // contains login button password field

        {
            MainPage = new LoginPage();
            //        messageLabel.TextColor = Color.Red;
            //        passwordEntry.IsPassword = true;

            //        var loginButton = new Button
            //        {
            //            Text = "Login",
            //        };

            //        loginButton.BackgroundColor = Color.Green;
            //        loginButton.TextColor = Color.White;

            //        loginButton.Clicked += OnLoginButtonClicked;

            //        var signupButton = new Button
            //        {
            //            Text = "Setup",
            //        };

            //        signupButton.BackgroundColor = Color.Green;
            //        signupButton.TextColor = Color.White;

            //        signupButton.Clicked += OnSetupButtonClicked;

            //        //var logo = new Image { Aspect = Aspect.AspectFit };
            //        //logo.Source = ImageSource.FromFile("logo.jpg");

            //        // Set up the loading wheel
            //        loadingWheel.Color = Color.Green;
            //        loadingWheel.IsRunning = true;
            //        loadingWheel.IsVisible = false;

            //        // The root page of your application
            //        var content = new ContentPage
            //        {

            //            Title = "Login",
            //            Content = new StackLayout
            //            {
            //                VerticalOptions = LayoutOptions.Center,
            //                Padding = new Thickness(40, 0, 40, 0),
            //                Children = {
            //                    //logo,
            //                        new Label { Text = "Sign In", TextColor=Color.Green, FontAttributes= FontAttributes.Bold, FontSize=18, Margin = new Thickness(0,80,0,20) },
            //                        new Label { Text = "Username" },
            //                        usernameEntry,
            //                        new Label { Text = "Password" },
            //                        passwordEntry,
            //                        loadingWheel,
            //                        loginButton,
            //                        signupButton,
            //                        messageLabel
            //                }
            //            }
            //        };

            //        MainPage = content;
        }

        //    private void OnSetupButtonClicked(object sender, EventArgs e)
        //    {
        //        MainPage = new SignUpPage();
        //    }

        //    private void OnLoginButtonClicked(object sender, EventArgs e)
        //    {
        //        var content = string.Empty;

        //        //Display Loading Wheel
        //        loadingWheel.IsVisible = true;

        //        content = passwordEntry.Text;

        //        if(content.ToLower() != "password"  || content == null)
        //        {
        //            // Hide loading wheel
        //            loadingWheel.IsVisible = false;

        //            messageLabel.Text = "Username or password incorrect. Please try again.";
        //            passwordEntry.Text = string.Empty;
        //        }
        //        else
        //        {
        //            var menuPage = new MenuPage();
        //            NavigationPage = new NavigationPage(new HomeViewPage());
        //            RootPage = new Views.MainPage();
        //            RootPage.Master = menuPage;
        //            RootPage.Detail = NavigationPage;
        //            MainPage = RootPage;
        //        }


        //    }
    }
}
