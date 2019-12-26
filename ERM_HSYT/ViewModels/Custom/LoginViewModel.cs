using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using ERM_HSYT.Views.CustomForm;
using System.Threading.Tasks;
using ERM_HSYT.Data;

namespace ERM_HSYT
{
    public class LoginViewModel
    {
        // list of hospital
        public List<HospitalInformation> Data { get; set; }

        // remember login
        private bool rememberme;
        public bool RememberMe
        {
            get => rememberme;
            set
            {
                rememberme = value;
                NotifyPropertyChanged(nameof(RememberMe));
            }
        }

        // username
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
               
                NotifyPropertyChanged(nameof(Username));
            }
        }

        // password
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        // index of hospital's image 
        private int imageIndex;
        public int ImageIndex
        {
            get
            {
                return imageIndex;
            }
            set
            {
                imageIndex = value;
                NotifyPropertyChanged(nameof(ImageIndex));
            }
        }

        // LoginCommand
        public ICommand LoginClickCommand { get; private set; }

        public LoginViewModel()
        {
            Data = App.HospitalDatabse.GetAllHospital();
            App.CurrentHospital = Data[ImageIndex].Clone();
            LoginClickCommand = new Command(async () => await LoginClick());
        }

        async Task LoginClick()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");
                return;
            }
            LoginUser user = new LoginUser(Username, Password);
            if (user.CheckInformation())
            {
                //DisplayAlert("Login", "Login success", "Oke");
                App.RestService = new RestService(Data[ImageIndex]);
                Token result = null;
                try
                {
                    result = await App.RestService.Login(user);
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Đăng nhập", "Sai tên đăng nhập hoặc mật khẩu.", "Oke");

                }

                if (result != null)
                {
                    if (result.access_token != null)
                    {
                        App.CurrentHospital = Data[ImageIndex].Clone();
                        App.IsRememberMe = RememberMe;
                        App.UserDatabase.SaveUser(user);
                        App.TokenDatabase.SaveToken(result);
                        App.SuccessLoginUserDatabase.DeleteAllUser();
                        App.SuccessLoginUserDatabase.SaveUser(new SuccessLoginUser(Username, ImageIndex, RememberMe));
                        // await Navigation.PushAsync(new DashboardCarouselPage());
                      
                        Application.Current.MainPage = new NavigationPage(new DashboardCarouselPage());
                        //if(Device.OS ==)
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Đăng nhập", "Sai tên đăng nhập hoặc mật khẩu.", "Oke");
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Đăng nhập", "Sai tên đăng nhập hoặc mật khẩu.", "Oke");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
