using ERM_HSYT.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ERM_HSYT.ViewModels.Custom
{
    public class DatLichHenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<KhoaPhong> DsKhoaPhong { get; set; }
        public List<string> DsTenKhoaPhong { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public string khoaPhong { get; set; }
        public string idKhoaPhong { get; set; }
        public string ghiChu { get; set; }

        public LichHenPost lichHenPost = new LichHenPost();

        public string userId { get; set; }
        public string hoTen { get; set; }
        public string sdt { get; set; }

        public DateTime MinDate { get; set; }

        public DatLichHenViewModel()
        {

            DsKhoaPhong = App.KhoaPhongDatabase.GetAllKhoaPhong();
            if (DsKhoaPhong != null)
            {

                DsTenKhoaPhong = DsKhoaPhong.Select(s => s.Name).ToList();        
            } else
            {
                LoadKhoaPhong();
            }
            //DsKhoaPhong = App.KhoaPhongDatabase.GetKhoaPhong("").ToList();
            date = DateTime.Now;
            MinDate = DateTime.Now;
            time = DateTime.Now.TimeOfDay;
        }


        async void LoadKhoaPhong()
        {
            DsKhoaPhong = await App.RestService.GetResponse<List<KhoaPhong>>(App.CurrentHospital.BaseUrl + "/khoaphongs");
            if (DsKhoaPhong == null)
            {
                Trace.Write("khoa phong null");
            }
            else
            {
                App.KhoaPhongDatabase.SaveKhoaPhong(DsKhoaPhong);
                DsTenKhoaPhong = DsKhoaPhong.Select(s => s.Name).ToList();
            }
        
        }
        // command
        public ICommand PostCommand
        {
            get
            {
                return new RelayCommand(DatLich);
            }
        }

        

        async void DatLich()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");
                return;
            }
            var user = App.UserDatabase.GetUser();
            var userProfile = await App.RestService.GetResponse<UserProfile>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username);
            userId = userProfile.Id;
            Trace.Write(userId);
            hoTen = userProfile.HoTen;
            sdt = userProfile.DienThoai;
            if (sdt == null) sdt = "";
            string datePost = date.ToString("yyyy-MM-dd");
            string timePost = new DateTime(time.Ticks).ToString("HH:mm:ss");
            string start = datePost + "T" + timePost + "Z";

            if (string.IsNullOrEmpty(khoaPhong))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Chưa chọn khoa phòng!", "OK");
                return;
            }
            
            if (string.IsNullOrEmpty(ghiChu) || ghiChu.Replace(" ", "").Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Lỗi", "Chưa nhập ghi chú!", "OK");
                return;
            }

          
            idKhoaPhong = DsKhoaPhong.Where(s => s.Name.Equals(khoaPhong)).Select(s => s.Id).First();
           
            detailLichHenPost meta = new detailLichHenPost(userId, hoTen, sdt, idKhoaPhong, "", sdt, ghiChu, userId);
            //lichHenPost.title = hoTen;
            //lichHenPost.start = start;
            //lichHenPost.meta.creator = userId;

            lichHenPost = new LichHenPost(hoTen, start, meta);


            // send request
            var response = await App.RestService.PostLichHen(App.CurrentHospital.BaseUrl + "/hsyt/lichhens", lichHenPost);
            if (!response)
            {
                // loi
                await App.Current.MainPage.DisplayAlert("Lỗi", "Đặt lịch không thành công", "Ok");
                return;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Đặt lịch ngày " + date.ToString("dd-MM-yyyy") + " thành công", "Ok");
                return;
            }
        }
    }
}
