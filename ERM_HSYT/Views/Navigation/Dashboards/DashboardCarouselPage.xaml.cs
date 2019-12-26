using Xamarin.Forms;
using UXDivers.Grial;
using System;
using ERM_HSYT.Models;
using ERM_HSYT.Data;
using ERM_HSYT.Views.CustomForm;
using Plugin.FirebasePushNotification;
using System.Diagnostics;

namespace ERM_HSYT
{
    public partial class DashboardCarouselPage : ContentPage
    {
        DashboardCarouselViewModel carouselVm = new DashboardCarouselViewModel();
        public DashboardCarouselPage()
        {
            InitializeComponent();
            BindingContext = carouselVm;
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                carousel.Position = (carousel.Position + 1) % carouselVm.Headers.Count;

                return true;
            }));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Triggers.Clear();
        }

        async void Logout_Click(object sender, EventArgs e)
        {
            var user = App.UserDatabase.GetUser();
            App.UserDatabase.DeleteAllUser();
            //await Navigation.PushAsync(new LoginView());
            var successLogin = App.SuccessLoginUserDatabase.GetUser();
            if (successLogin != null)
            {
                successLogin.RememberMe = false;
                App.SuccessLoginUserDatabase.SaveUser(successLogin);
            }
            App.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}