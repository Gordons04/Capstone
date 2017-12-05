using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GreenHomeAdvisor.Database;
using Android.Net;
using GreenHomeAdvisor.Droid.Database;

[assembly : Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace GreenHomeAdvisor.Droid.Database
{
    public class NetworkConnection : initNetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);   //Uses Android Connectivity Manager
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;

            if(ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)  //Checks for valid network info and a connected status
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}