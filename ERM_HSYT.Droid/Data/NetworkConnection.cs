using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ERM_HSYT.Data;
using ERM_HSYT.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace ERM_HSYT.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetWorkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if(ActiveNetworkInfo == null && ActiveNetworkInfo.IsConnectedOrConnecting)
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