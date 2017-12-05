using GreenHomeAdvisor.Entity;
using GreenHomeAdvisor.Models;
using GreenHomeAdvisor.Views;
using GreenHomeAdvisor.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHomeAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
     
        }

        public void Init()      //Setup all colors and flow structure of entrys
        {
            signInLabel.TextColor = Constants.mainTextColor;

            LoginButton.BackgroundColor = Constants.buttonBackgroundColor;
            LoginButton.TextColor = Constants.buttonTextColor;
            SignUpButton.BackgroundColor = Constants.buttonBackgroundColor;
            SignUpButton.BackgroundColor = Constants.buttonTextColor;

            loadingWheel.IsRunning = true;
            loadingWheel.IsVisible = false;

            usernameEntry.Completed += (s, e) => passwordEntry.Focus();     //Easy navigation through fields
            passwordEntry.Completed += (s, e) => LoginButtonClicked(s, e);
        }


        async void LoginButtonClicked(object sender, EventArgs e)     //Login Routine
        {
            StatusLabel.Text = null;        //Reset error message
            loadingWheel.IsVisible = true;
            User user = new User(usernameEntry.Text, passwordEntry.Text);

            if (user.checkCredentials())
            {
                await DisplayAlert("Login Success", "Login Successful", "Okay");
                var result = new Token();                       //Work around: here we will impliment a token API call
                if (result != null)
                {
                    //App.UserDatabase.saveUser(user);                //Save user to DB when credentials are correct
                    //App.TokenDatabase.saveToken(result);            //Save token to memory (SQLite db held in .txt file)
                    loadingWheel.IsVisible = false;   
                    if(Device.OS == TargetPlatform.Android)         //Deals with navigation to homepage on each platform
                    {
                        Application.Current.MainPage = new MasterDetail();
                    }   
                    else if(Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushAsync(new MasterDetail()); //Move to home page
                    }           
                }

            }
            else if (!App.CheckInternetConnection())        //Bad internet Connection
            {
                StatusLabel.Text = Constants.NoInternetText;
                loadingWheel.IsVisible = false;
                passwordEntry.Text = string.Empty;
            }
            else                                           //Bad Username/Password
            { 
                StatusLabel.Text = Constants.WrongLoginText;
                loadingWheel.IsVisible = false;
                passwordEntry.Text = string.Empty;
            }
        }

        async void SignUpButtonClicked(object sender, EventArgs e)      //Deals with the Signup page navigation
        {
            if (Device.OS == TargetPlatform.Android)                    //Deals with navigation to signup page on each platform
            {
                Application.Current.MainPage = new NavigationPage(new SignUpPage());
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushAsync(new SignUpPage());           //Move to signup page
            }

        }
    }
}
