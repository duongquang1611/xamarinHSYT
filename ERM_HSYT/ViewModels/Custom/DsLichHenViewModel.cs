using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM_HSYT.ViewModels.Custom
{
    public class DsLichHenViewModel : ObservableObject
    {
        public DsLichHenViewModel() : base(listenCultureChanges: true)
        {
            LoadData();
            //LoadDataKhoaPhong();
            //LoadDataBacSi();
        }

        public ObservableCollection<LichHenView> DsLichHens { get; } = new ObservableCollection<LichHenView>();
        public ObservableCollection<KhoaPhong> DsKhoaPhong { get; } = new ObservableCollection<KhoaPhong>();
        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
            //LoadDataKhoaPhong();
            //LoadDataBacSi();
        }


        private async void LoadData()
        {
            DsLichHens.Clear();
            var user = App.UserDatabase.GetUser();
            var userProfile = await App.RestService.GetResponse<UserProfile>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + user.Username);
            int _STT = 1;
            //var idBenhNhanTest = "8326a8e5-a7e1-445e-9e74-c9e5482ee9b7";
            //user.AppId = idBenhNhanTest;
            var lstLichHen = await App.RestService.GetResponse<List<LichHenData>>(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + userProfile.Id + "/lichhens");
            Trace.Write(userProfile.Id);
            Trace.Write(user.Username);
            Trace.Write(App.CurrentHospital.BaseUrl + "/hsyt/benhnhans/" + userProfile.Id + "/lichhens");
            if (lstLichHen != null && lstLichHen.Count > 0)
            {
                foreach (var lh in lstLichHen)
                {

                    DateTime myDate = DateTime.Parse(lh.start);
                    if (lh.meta.room == null)
                    {
                        lh.meta.room = "Chưa có phòng khám";
                    }
                    else
                    {
                        lh.meta.room = App.KhoaPhongDatabase.GetKhoaPhong(lh.meta.room)[0].Name;
                    }
                    DsLichHens.Add(new LichHenView()
                    {
                        STT = _STT,
                        Ma = lh.id,
                        Room = "Phòng: " + lh.meta.room,
                        Ngay = myDate.ToString("dd MM yyyy"),
                        Gio = myDate.ToString("HH:mm:ss"),
                        ITrangThai = 0,
                        GhiChu = "Ghi chú: " + lh.meta.note,
                        BenhNhan = new BenhNhan()
                        {
                            Name = lh.title,
                            Avatar = "user_default.png"
                        }
                    });
                    Debug.WriteLine(lh.meta.room);
                    _STT++;
                }
            }

            // khoa phong
            List<KhoaPhong> listKhoaPhong = await App.RestService.GetResponse<List<KhoaPhong>>(App.CurrentHospital.BaseUrl + "/khoaphongs");
            if (listKhoaPhong == null)
            {
                Trace.Write("khoa phong null");
                //return null;
            }
            else
            {
                //return listKhoaPhong;
                //int i = 1;
                //foreach (KhoaPhong kp in listKhoaPhong)
                //{

                //    Trace.Write(i + " " + kp.Name);
                //    i++;
                //}
                //Trace.Write(App.CurrentHospital.BaseUrl + "khoaphongs");

                // luu khoa phong vao sqlite 
                App.KhoaPhongDatabase.SaveKhoaPhong(listKhoaPhong);

                // get test data khoa phong
                //List<KhoaPhong> listKhoaPhong2 = App.KhoaPhongDatabase.GetKhoaPhong("");
                //foreach (KhoaPhong kp2 in listKhoaPhong2)
                //{
                //    Trace.Write(kp2.Name);
                //}
            }


            // bac si
            var rootBacSi = await App.RestService.GetResponse<RootBacSi>(App.CurrentHospital.BaseUrl + "/canbos/showByDomain");
            Trace.Write("RootBacSi");
            Trace.Write(rootBacSi);
            if (rootBacSi == null)
            {
                Trace.Write("Bac Si Null");
            }
            else



            {
                Trace.Write(App.CurrentHospital.BaseUrl + "/canbos/showByDomain");
                List<List> listBacSi = rootBacSi.List.ToList<List>();
                // luu bac si vao sqlite
                App.BacSiDatabase.SaveBacSi(listBacSi);
                int i = 1;
                foreach (List bacSi in listBacSi)
                {
                    Trace.Write(i + " " + bacSi.HoTen);
                    i++;
                }
            }

        }

        //private async void LoadDataKhoaPhong()

        //{
        //    List<KhoaPhong> listKhoaPhong = await App.RestService.GetResponse<List<KhoaPhong>>(App.CurrentHospital.BaseUrl + "/khoaphongs");
        //    if (listKhoaPhong == null)
        //    {
        //        Trace.Write("khoa phong null");
        //        //return null;
        //    }
        //    else
        //    {
        //        //return listKhoaPhong;
        //        //int i = 1;
        //        //foreach (KhoaPhong kp in listKhoaPhong)
        //        //{

        //        //    Trace.Write(i + " " + kp.Name);
        //        //    i++;
        //        //}
        //        //Trace.Write(App.CurrentHospital.BaseUrl + "/khoaphongs");

        //        // luu khoa phong vao sqlite 
        //        App.KhoaPhongDatabase.SaveKhoaPhong(listKhoaPhong);

        //        // get test data khoa phong
        //        //List<KhoaPhong> listKhoaPhong2 = App.KhoaPhongDatabase.GetKhoaPhong("");
        //        //foreach (KhoaPhong kp2 in listKhoaPhong2)
        //        //{
        //        //    Trace.Write(kp2.Name);
        //        //}
        //    }
        //}

        //private async void LoadDataBacSi()
        //{
        //    var rootBacSi = await App.RestService.GetResponse<RootBacSi>(App.CurrentHospital.BaseUrl + "/canbos/showByDomain");
        //    Trace.Write(rootBacSi);
        //    Trace.Write(App.CurrentHospital.BaseUrl + "/canbos/showByDomain");
        //    if (rootBacSi == null)
        //    {
        //        Trace.Write("Bac Si Null");
        //    }
        //    else
        //    {
        //        List<List> listBacSi = rootBacSi.List.ToList<List>();
        //        // luu bac si vao sqlite
        //        App.BacSiDatabase.SaveBacSi(listBacSi);
        //        int i = 1;
        //        foreach (List bacSi in listBacSi)
        //        {
        //            Trace.Write(i + " " + bacSi.HoTen);
        //            i++;
        //        }
        //    }
        //}
    }
}
