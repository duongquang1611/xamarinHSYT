using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace ERM_HSYT.ViewModels.Custom
{
    public class MedicinesViewModel : ObservableObject
    {
        public ObservableCollection<MedicineInfo> MedicineList { get; } = new ObservableCollection<MedicineInfo>();

        public MedicinesViewModel() : base(listenCultureChanges: true)
        {
            LoadData();
        }

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
                        MedicineList.Add(new MedicineInfo()
                        {
                            PkId = pk.Id,
                            NgayKham = string.Format("Ngày khám: {0}", pk.NgayKham.ToShortDateString()),
                            IsExpired = false,
                            DanhSachThuoc = phieuKham.LstDonThuoc
                        });

                }
            }
        }
    }


    public class MedicineInfo {
        public Guid PkId { get; set; }
        public string NgayKham { get; set; }
        public bool IsExpired { get; set; }
        public List<HSDonThuocModel> DanhSachThuoc { get; set; }
    }
}
