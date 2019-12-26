using ERM_HSYT.Models;
using ERM_HSYT.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT
{
    // https://docs.grialkit.com/grid-view.html
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HienThiLanKham : ContentPage
    {
       
        public HienThiLanKham(Guid id)
        {
            InitializeComponent();
            LoadData(id);
        }

        private async void LoadData(Guid id)
        {
            var phieuKham = await App.RestService.GetResponse<PhieuKhamViewModel>(App.CurrentHospital.BaseUrl + "/hsyt/lankhams/" + id);
            if(phieuKham != null)
            {
                phieuKham.LstPhieuChiDinh = phieuKham.LstPhieuChiDinh.Where(pcd => pcd.IdPhieuIn != Guid.Empty).ToList();
                int _STT = 1;
                foreach (HSDonThuocModel thuoc in phieuKham.LstDonThuoc)
                {
                    thuoc.STT = _STT++;
                }
                BindingContext = phieuKham;
            }
        }

    }
}