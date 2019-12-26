using ERM_HSYT.Data;
using ERM_HSYT.Models;
using ERM_HSYT.Views.CustomForm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ERM_HSYT.ViewModels.Custom
{
    public class ChangePasswordViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        RestService apiService;
        UserDatabaseController userDatabase;
        #endregion

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        #region Constructors
        public ChangePasswordViewModel()
        {
            apiService = new RestService();

        }
        #endregion

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        async void Save()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");
                return;
            }
            if (string.IsNullOrEmpty(CurrentPassword))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Bạn phải nhập vào mật khẩu hiện tại", "ok");
                return;
            }

            var user = App.UserDatabase.GetUser();
            var userProfile = await App.RestService.GetResponse<UserProfile>(Constants.BaseUrl + "/hsyt/benhnhans/" + user.Username);
           

            if (!user.Password.Equals(CurrentPassword))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Mật khẩu nhập vào không đúng", "ok");
                return;
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Bạn phải nhập vào mật khẩu mới", "ok");
                return;
            }

            if (NewPassword.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Mật khẩu mới phải có ít nhất 6 kí tự", "ok");
                return;
            }

            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Bạn phải nhập lại mật khẩu mới để xác nhận", "ok");
                return;
            }

            if (!NewPassword.Equals(ConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Mật khẩu xác nhận không trùng với mật khẩu mới", "ok");
                return;
            }


            var changePasswordRequest = new ChangePasswordRequest
            {
                OldPassword = CurrentPassword,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmPassword
            };

            //https://bvdkdongda.hosoyte.com/api/accounts/ChangePassword?userId=42e48c42-a51b-492b-a5e5-cb4854d4af7e
            var token = App.TokenDatabase.GetToken();
            var response = await apiService.ChangePassword("https://bvdkdongda.hosoyte.com/api/accounts/ChangePassword?userId=" + userProfile.Id,  token.access_token, changePasswordRequest);

            if (!response)
            {
                // xac nhan loi 
                await App.Current.MainPage.DisplayAlert("Lỗi", "Xảy ra lỗi!!!", "ok");
                return;
            }

            await App.Current.MainPage.DisplayAlert("ok", "Bạn đã thay đổi mật khẩu thành công", "ok");
            user.Password = NewPassword;
            App.UserDatabase.SaveUser(user);
            App.TokenDatabase.DeleteAllToken();
            var slUser = App.SuccessLoginUserDatabase.GetUser();
            if (slUser != null)
            {

                App.SuccessLoginUserDatabase.SaveUser(new SuccessLoginUser(slUser.Username, slUser.IndexHospitalImage, false));
            }
            App.Current.MainPage = new NavigationPage(new LoginView());


            // xac nhan ok


        }
        #endregion
    }
}
