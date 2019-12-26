using ERM_HSYT.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class MessagesListViewModel : ObservableObject
    {
        public MessagesListViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public ObservableCollection<MessageData> Messages { get; } = new ObservableCollection<MessageData>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private async void LoadData()
        {
            Messages.Clear();
            var user = App.UserDatabase.GetUser();
            //    var lstPhieuKham = await App.RestService.GetResponse<List<LanKham>>(Constants.BaseUrl + "/benhnhans/" + user.Username + "/lankhams?pageIndex=1&pageSize=100");
            var lstPhieuKham = await App.RestService.GetResponse<List<LanKham>>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username + "/lankhams?pageIndex=1&pageSize=100");

            if (lstPhieuKham != null && lstPhieuKham.Count > 0)
            {
                foreach (var pk in lstPhieuKham)
                {
                    Messages.Add(new MessageData()
                    {
                        Id = pk.Id,
                        Title = pk.TenPhongKham,
                        Body = string.Format("Chẩn đoán: {0} - {1}", pk.MaICD, pk.ChanDoan),
                        IsStared = pk.IsUuTien,
                        When = "",
                        IsRead = false,
                        HasAttachment = false,
                        ThreadCount = 0,
                        From = new ChatUserData()
                        {
                            Name = string.Format("Ngày khám: {0}", pk.NgayKham.ToShortDateString()),
                            Avatar = ""
                        }
                    });
                }
            }
        }
    }
}
