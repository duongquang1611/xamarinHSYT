using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DsLichHenTemplate2 : ContentPage
    {
        public DsLichHenTemplate2()
        {
            InitializeComponent();
            BindingContext = new DsLichHenViewModel();
        }

        private async void OnMore(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            await DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            await DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            var selectedItem = ((ListView)sender).SelectedItem;
            var id = ((MessageData)selectedItem).Id;

            await Application.Current.MainPage.Navigation.PushAsync(new HienThiLanKham(id));
        }

        private void OnRefreshing(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            listView.EndRefresh();
        }

        //private async void FloatingActionButton_Clicked(object sender, EventArgs e)
        //{
        //    await Application.Current.MainPage.Navigation.PushModalAsync(new DatLichHen());
        //}

    }
}