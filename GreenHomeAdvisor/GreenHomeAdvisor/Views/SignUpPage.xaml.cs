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
            //if(usernameEntry.Text in DB){           //Put API call into place to call DB for repeat username
            //    await DisplayAlert("Username Taken", "Username already in use, please try again", "Okay");
            //    usernameEntry.Text = null;
            //    usernameEntry.BackgroundColor = Color.Red;
            //    errorFlag = true;
            //}

            if ((passwordEntry.Text != passwordSecondEntry.Text) || (passwordEntry.Text == null || passwordSecondEntry.Text == null))      //Ensure both passwords match
            {
                await DisplayAlert("Invalid Password", "Passwords do not match or they are both empty, please try again", "Okay");
                passwordEntry.Text = null;
                passwordEntry.BackgroundColor = Color.Red;
                passwordSecondEntry.Text = null;
                passwordSecondEntry.BackgroundColor = Color.Red;
                errorFlag = true;
            }

            if(errorFlag != true)               //Check to see if any errors were thrown through the signup process
            {
                //Save user to database for future login

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
