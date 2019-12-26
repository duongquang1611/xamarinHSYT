using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {

        LoginViewModel Lvm = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();

            SuccessLoginUser user = App.SuccessLoginUserDatabase.GetUser();
            if (user != null)
            {
                Lvm.Username = user.Username;
                Lvm.ImageIndex = user.IndexHospitalImage;
                Lvm.RememberMe = user.RememberMe;
            }
            else
            {
                Lvm.Username = String.Empty;
                Lvm.ImageIndex = 0;
                Lvm.RememberMe = false;
            }

            this.BindingContext = Lvm;
            //entryUsername.Focused += async (s, e) =>

            //{
            //    await scrollView.ScrollToAsync(0, 200, true);
            //};

            //entryPassword.Focused += async (s, e) =>
            //{
            //    await scrollView.ScrollToAsync(entryUsername, ScrollToPosition.Start, true);
            //};

        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            

            entryUsername.Focused += async (s, e) =>
            {
                await scrollView.ScrollToAsync(entryUsername, ScrollToPosition.Start, true);
            };

            entryPassword.Focused += async (s, e) =>
            {
                await scrollView.ScrollToAsync(entryUsername, ScrollToPosition.Start, true);
            };

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //App.UserDatabase.DeleteAllUser();
            //if (!Lvm.RememberMe)
            //{
            //    App.SuccessLoginUserDatabase.DeleteAllUser();
            //}
        }



    }
}