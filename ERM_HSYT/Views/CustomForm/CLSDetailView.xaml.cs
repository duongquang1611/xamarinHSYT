using ERM_HSYT.ViewModels;
using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ERM_HSYT.ViewModels.Custom.CLSViewModel;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CLSDetailView : ContentPage
    {
        public CLSDetailView(List<HSPhieuChiDinhModel> dscd, string ngaykham)
        {
            {
                InitializeComponent();
                BindingContext = new CLSDetailViewModel(dscd, ngaykham);
            }
        }
    }
}