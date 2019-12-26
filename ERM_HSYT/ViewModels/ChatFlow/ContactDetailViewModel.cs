using System.Collections.Generic;
using System.Linq;
using UXDivers.Grial;
using ERM_HSYT.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ERM_HSYT
{
    public class ContactDetailViewModel : ObservableObject
    {
        private string _avatar;
        private string _hoten;
        private string _diachi;
        //private readonly string _contactId;
        //private FlowContactData _contact;

        public ContactDetailViewModel()
             : base(listenCultureChanges: true)
        {
            LoadData();
        }
        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
        }
        public string Hoten
        {
            get { return _hoten; }
            set { SetProperty(ref _hoten, value); }
        }
        public string Diachi
        {
            get { return _diachi; }
            set { SetProperty(ref _diachi, value); }
        }

        public ObservableCollection<ValueData> Values { get; } = new ObservableCollection<ValueData>();
        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }
        private async void LoadData()
        {
            Values.Clear();
            var user = App.UserDatabase.GetUser();
            var userProfile = await App.RestService.GetResponse<UserProfile>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username);
            if (userProfile != null)
            {
                Values.Add(new ValueData()
                {
                    Label = "Mã đăng nhập",
                    Value = user.Username
                });
                
                Values.Add(new ValueData()
                {
                    Label = "Họ tên",
                    Value = userProfile.HoTen
                });
                Values.Add(new ValueData()
                {
                    Label = "Số thẻ bảo hiểm",
                    Value = userProfile.SoBHYT
                });
                Values.Add(new ValueData()
                {
                    Label = "Giới tính",
                    Value = userProfile.GioiTinh ? "Nam":"Nữ"
                });
                Values.Add(new ValueData()
                {
                    Label = "Ngày sinh",
                    Value = userProfile.NgaySinh != null ? userProfile.NgaySinh.ToString("dd/MM/yyyyy") : ""

                });
                Values.Add(new ValueData()
                {
                    Label = "Điện thoại",
                    Value = userProfile.DienThoai
                });
                Values.Add(new ValueData()
                {
                    Label = "Địa chỉ",
                    Value = userProfile.DiaChi
                });
                Avatar = "user_default.png";
                Hoten = userProfile.HoTen;
                Diachi = userProfile.DiaChi;
            }
            else
            {
                Values.Add(new ValueData()
                {
                    Label = "Username",
                    Value = user.Username
                });
            }
            //JsonHelper.Instance.LoadViewModel(this, source: "Social.json");
        }

        public class ValueData
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }
    }
}
