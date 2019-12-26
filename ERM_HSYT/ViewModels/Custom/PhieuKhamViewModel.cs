using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace ERM_HSYT.ViewModels
{
    public class PhieuKhamViewModel
    {
        public string Domain { get; set; }
        public string Ma { get; set; }
        public Guid IdBenhNhan { get; set; }
        public Guid? IdBenhAn { get; set; }
        public string Tuoi { get; set; }
        public string TenKhoaKham { get; set; }
        public string TenPhongKham { get; set; }
        public Guid? IdBacSiKham { get; set; }
        public Guid? IdNguoiNhap { get; set; }
        public DateTime NgayKham { get; set; }
        public bool IsBHYT { get; set; }
        public string NoiDungKham { get; set; }
        public string ChanDoanBS { get; set; }
        public Guid? IdBenhChinh { get; set; }
        public string DmBenhKemTheo { get; set; }
        public string GhiChu { get; set; }
        // Additional data
        public string TenBenhNhan { get; set; }
        public string TenBacSi { get; set; }
        public string MaICD { get; set; }
        // Detail data
        public List<HSPhieuChiDinhModel> LstPhieuChiDinh { get; set; }
        public List<HSChiDinhDVKTModel> LstChiDinh { get; set; }
        public List<HSDonThuocModel> LstDonThuoc { get; set; }
    }

    public class HSPhieuChiDinhModel
    {
        public string Domain { get; set; }
        public string Ma { get; set; }
        public Guid? IdPhieuKham { get; set; }
        public Guid IdBenhNhan { get; set; }
        public string MaLanKham { get; set; }
        public string KetQua { get; set; }
        public string KetLuan { get; set; }
        public string LinkUrls
        {
            get { return "https://mmjrecs.com/wp-content/uploads/2016/12/icon_MedHistory.png"; }
            set { }
        }
        public string TenBacSiChiDinh { get; set; }
        public string TenKhoaChiDinh { get; set; }
        public string TenPhongChiDinh { get; set; }
        public Guid IdPhieuIn { get; set; }
        public string PhieuIn
        {
            get
            {
                return string.Format("https://bvdkdongda.hosoyte.com/api/01004/HSPhieuIn/{0}/html", IdPhieuIn.ToString());
            }
            set { }
        }
    }

    public class HSChiDinhDVKTModel
    {
        public string Domain { get; set; }
        public Guid IdPhieuKham { get; set; }
        public Guid IdPhieuDVKT { get; set; }
        public string MaLanKham { get; set; }
        public string TenKhoaChiDinh { get; set; }
        public string TenBacSi { get; set; }
        public string KetQua { get; set; }
        public string KetLuan { get; set; }
        public string GhiChu { get; set; }
        public DateTime? NgayTao { get; set; }
    }

    public class HSDonThuocModel
    {
        public int STT { get; set; }
        public Guid Id { get; set; }
        public string MaLanKham { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public string DonVi { get; set; }
        public string LieuDung { get; set; }
    }
}
