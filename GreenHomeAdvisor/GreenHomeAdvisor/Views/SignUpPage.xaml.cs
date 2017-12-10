using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GreenHomeAdvisor.Entity;

namespace GreenHomeAdvisor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private bool errorFlag;

        public SignUpPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            usernameEntry.Text = "";
            passwordEntry.Text = "";
            passwordSecondEntry.Text = "";

            usernameEntry.Completed += (s, e) => passwordEntry.Focus();     //Easy navigation through fields
            passwordEntry.Completed += (s, e) => passwordSecondEntry.Focus();
            passwordSecondEntry.Completed += (s, e) => SubmitButtonClicked(s, e);
        }

        async void SubmitButtonClicked(object sender, EventArgs e)
        {
            errorFlag = false;
            usernameEntry.BackgroundColor = Color.White;
            passwordEntry.BackgroundColor = Color.White;
            passwordSecondEntry.BackgroundColor = Color.White;

            //if(usernameEntry.Text in DB){           //Put API call into place to call DB for repeat username
            //    await DisplayAlert("Username Taken", "Username already in use, please try again", "Okay");
            //    usernameEntry.Text = null;
            //    usernameEntry.BackgroundColor = Color.Red;
            //    errorFlag = true;
            //}

            if (!passwordEntry.Text.Equals(passwordSecondEntry.Text))       //Passwords don't match
            {
                await DisplayAlert("Invalid Password", "Passwords do not match, please try again", "Okay");
                passwordEntry.Text = "";
                passwordEntry.BackgroundColor = Color.Red;
                passwordSecondEntry.Text = null;
                passwordSecondEntry.BackgroundColor = Color.Red;
                errorFlag = true;
            }

            if(passwordEntry.Text == null || passwordSecondEntry.Text == null || passwordEntry.Text == "" || passwordSecondEntry.Text == "")    //Password was left blank
            {
                await DisplayAlert("Invalid Password", "Password was left blank, please try again", "Okay");
                passwordEntry.Text = "";
                passwordEntry.BackgroundColor = Color.Red;
                passwordSecondEntry.Text = "";
                passwordSecondEntry.BackgroundColor = Color.Red;
                errorFlag = true;
            }

            if (usernameEntry.Text == null || usernameEntry.Text == "")
            {
                await DisplayAlert("Invalid Username", "Username can not be left blank, please try again", "Okay");
                usernameEntry.Text = "";
                usernameEntry.BackgroundColor = Color.Red;
                errorFlag = true;
            }

            if(errorFlag != true)               //Check to see if any errors were thrown through the signup process
            {
                //Save user to database for future login
                User newUser = new User(usernameEntry.Text, passwordEntry.Text);
                App.UserDatabase.saveUser(newUser);

                await DisplayAlert("Account Created", "Account was created successfully", "login");

                if (Device.OS == TargetPlatform.Android)                    //Deals with navigation to login page on each platform
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
                else if (Device.OS == TargetPlatform.iOS)
                {
                    await Navigation.PushAsync(new LoginPage());           //Move to login page
                }
            }
        }

        async void CancelButtonClicked(object sender, EventArgs e)      //Returns to login screen
        {
            if (Device.OS == TargetPlatform.Android)                    //Deals with navigation to login page on each platform
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushAsync(new LoginPage());           //Move to login page
            }
        }
    }
}
