using System;
using Xamarin.Forms;
using UXDivers.Grial;
using ERM_HSYT.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace ERM_HSYT
{
    public partial class SimpleLoginPage : ContentPage
    {
        public SimpleLoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            //App.StartCheckIfInternet
            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => LoginClick(s, e);
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        async void LoginClick(object sender, EventArgs e)
        {
            LoginUser user = new LoginUser(entryUsername.Text, entryPassword.Text);
            if (user.CheckInformation())
            {
                //DisplayAlert("Login", "Login success", "Oke");
                var result = await App.RestService.Login(user);
                if (result.access_token != null)
                {
                    App.UserDatabase.SaveUser(user);
                    App.TokenDatabase.SaveToken(result);

                    //await Navigation.PushAsync(new DashboardCarouselPage());
                    Application.Current.MainPage = new NavigationPage(new DashboardCarouselPage());
                    //if(Device.OS ==)
                }
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password.", "Oke");
            }
        }
    }
}

