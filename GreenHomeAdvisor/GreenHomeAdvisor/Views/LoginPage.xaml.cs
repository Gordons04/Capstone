using GreenHomeAdvisor.Entity;
using GreenHomeAdvisor.Models;
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

            usernameEntry.Completed += (s, e) => passwordEntry.Focus();
            passwordEntry.Completed += (s, e) => LoginButtonClicked(s, e);
        }


        private void LoginButtonClicked(object sender, EventArgs e)     //Login Routine
        {
            loadingWheel.IsVisible = true;
            User user = new User(usernameEntry.Text, passwordEntry.Text);
            if (user.checkCredentials())
            {
                DisplayAlert("Login Success", "Login Successful", "Try Again");
                loadingWheel.IsVisible = false;
                //var menuPage = new MenuPage();
                //App.NavigationPage = new NavigationPage(new HomeViewPage());
                //App.RootPage = new Views.MainPage();
                //App.RootPage.Master = menuPage;
                //App.RootPage.Detail = App.NavigationPage;
                //MainPage = App.RootPage;

            }
            else
            {
                DisplayAlert("Login Failure", "Username or password was incorrect", "Try Again");
                loadingWheel.IsVisible = false;
                passwordEntry.Text = string.Empty;
            }
        }

        private void SignUpButtonClicked(object sender, EventArgs e)
        {
            

        }
    }
}
