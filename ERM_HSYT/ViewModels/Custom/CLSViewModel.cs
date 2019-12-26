using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERM_HSYT.ViewModels.Custom
{
    public class CLSViewModel : ObservableObject
    {
        public CLSViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public ObservableCollection<CLSInfor> CLSList { get; } = new ObservableCollection<CLSInfor>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData(); 
        }

        async void LoadData()
        {
            var user = App.UserDatabase.GetUser();
            //    var lstPhieuKham = await App.RestService.GetResponse<List<LanKham>>(Constants.BaseUrl + "/benhnhans/" + user.Username + "/lankhams?pageIndex=1&pageSize=100");
            var lstPhieuKham = await App.RestService.GetResponse<List<LanKham>>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username + "/lankhams?pageIndex=1&pageSize=100");

            if (lstPhieuKham != null && lstPhieuKham.Count > 0)
            {
                foreach (var pk in lstPhieuKham)
                {
                    var phieuKham = await App.RestService.GetResponse<PhieuKhamViewModel>(App.CurrentHospital.BaseUrl + "/hsyt/lankhams/" + pk.Id);
                    if (phieuKham != null)
                        CLSList.Add(new CLSInfor()
                        {
                            PkId = pk.Id,
                            NgayKham = string.Format("Ngày khám: {0}", pk.NgayKham.ToShortDateString()),
                            IsExpired = false,
                            DanhSachChiDinh = phieuKham.LstPhieuChiDinh.Where(pcd => pcd.IdPhieuIn != Guid.Empty).ToList()
                        });

                }
            }
        }

        public class CLSInfor
        {
            public Guid PkId { get; set; }

            public string NgayKham { get; set; }

            public bool IsExpired { get; set; }
            public List<HSPhieuChiDinhModel> DanhSachChiDinh { get; set; }
        }
    }
}

