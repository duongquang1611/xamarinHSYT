
using ERM_HSYT.Models;
using ERM_HSYT.ViewModels.Custom;
using ERM_HSYT.Views.CustomForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatLichHen : ContentPage
    {

        public DatLichHen()
        {
            InitializeComponent();
            //var now = App.KhoaPhongDatabase.GetAllKhoaPhong();
            //if (now != null)
            //{
            //    DsKhoaPhong = now;
            //} 
            //khoaPhongPicker.ItemsSource = DsKhoaPhong.Select(s => s.Name).ToList<string>();
            datePicker.Date = DateTime.Now;
            timePicker.Time = DateTime.Now.TimeOfDay;
            BindingContext = new DatLichHenViewModel();
        }

               

        //private async void ThemLichHenButton(object sender, EventArgs e)
        //{

        //    // button dat lich
        //    Trace.Write("Click button dat lich");
        //    LichHenPost lichHenPost = await CreateData();
        //    var json = JsonConvert.SerializeObject(lichHenPost);
        //    Trace.Write(json);
        //    try
        //    {
        //        var response = await App.RestService.PostLichHen(App.CurrentHospital.BaseUrl + "/hsyt/lichhens", lichHenPost);
        //        if (response)
        //        {
        //            await DisplayAlert("Thông báo", "Đặt lịch thành công", "OK");
        //        }
        //        else
        //        {
        //            await DisplayAlert("Lỗi", "Đặt lịch không thành công", "OK");
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        await DisplayAlert("Lỗi", "Đặt lịch không thành công", "OK");
        //    }
        //}

        private async void HuyButton(object sender, EventArgs e)
        {
            bool check = await DisplayAlert("Xác nhận?", "Bạn có muốn huỷ lịch hẹn", "Đồng ý", "Huỷ");
            if (check)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        //private async Task<LichHenPost> CreateData()
        //{
        //    Trace.Write("Create Data Function");
        //    var user = App.UserDatabase.GetUser();
        //    var userProfile = await App.RestService.GetResponse<UserProfile>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username);


        //    // create data
        //    string date = datePicker.Date.ToString("yyyy-MM-dd");
        //    string time = timePicker.Time.ToString();
        //    string start = date + "T" + time + "Z";
        //    string khoaPhong = khoaPhongPicker.SelectedItem.ToString();
        //    string idKhoaPhong = "";
        //    string ghiChu = ghiChuEditor.Text.Trim().ToString();

        //    string userId = userProfile.Id;
        //    string hoTen = userProfile.HoTen;
        //    string sdt = userProfile.DienThoai;
        //    if (sdt == null) sdt = "";

        //    LichHenPost lichHenPost = new LichHenPost();

        //    if (khoaPhong == "" || ghiChu == "")
        //    {
        //        await DisplayAlert("Thiếu thông tin!", "Vui lòng điền đầy đủ thông tin", "OK");
        //    }
        //    else
        //    {
        //        idKhoaPhong = DsKhoaPhong.Where(s => s.Name == khoaPhong).Select(s => s.Id).First();
        //        detailLichHenPost meta = new detailLichHenPost(userId, hoTen, sdt, idKhoaPhong, "", sdt, ghiChu, userId);
        //        lichHenPost = new LichHenPost(hoTen, start, meta);
        //    }

        //    return lichHenPost;
        //}

    }
}