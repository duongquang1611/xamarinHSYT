using ERM_HSYT.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class ContactSimpleDetailViewModel : ObservableObject
    {
        private string _avatar;

        public ContactSimpleDetailViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public string Avatar
        {
            get { return _avatar; }
            set { SetProperty(ref _avatar, value); }
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
            var userProfile = await App.RestService.GetResponse<UserProfile>(Constants.BaseUrl +  "/benhnhans/" + user.Username);
            if (userProfile != null)
            {
                Values.Add(new ValueData()
                {
                    Label = "Username",
                    Value = user.Username
                });
                Values.Add(new ValueData()
                {
                    Label = "Mã",
                    Value = userProfile.Ma
                });
                Values.Add(new ValueData()
                {
                    Label = "Họ tên",
                    Value = userProfile.HoTen
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
                Avatar = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/user_02.png";
                var hoTen = userProfile.HoTen;
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
        //public FlowContactData Contact
        //{
        //    get { return _contact; }
        //    set
        //    {
        //        if (SetProperty(ref _contact, value))
        //        {
        //            NotifyPropertyChanged(nameof(Values));
        //        }
        //    }
        //}
    }
}
