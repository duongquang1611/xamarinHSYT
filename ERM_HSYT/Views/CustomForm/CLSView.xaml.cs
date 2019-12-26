using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ERM_HSYT.ViewModels.Custom.CLSViewModel;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CLSView : ContentPage
    {
        public CLSView()
        {
            InitializeComponent();
            BindingContext = new CLSViewModel();
        }

        private void OnRefreshing(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            listView.EndRefresh();
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem;
            var CLS = ((CLSInfor)selectedItem);
            Trace.WriteLine("OOOOOOOOOOOOOOOOO " + CLS.DanhSachChiDinh.Count);
            await Application.Current.MainPage.Navigation.PushAsync(new CLSDetailView(CLS.DanhSachChiDinh, CLS.NgayKham));
        }
    }
}