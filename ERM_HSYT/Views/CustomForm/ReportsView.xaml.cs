using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsView : ContentPage
    {
        public ReportsView()
        {
            InitializeComponent();
            BindingContext = new ReportsViewModel();
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
            //var selectedItem = ((ListView)sender).SelectedItem;
            //var id = ((MessageData)selectedItem).Id;

            //await Application.Current.MainPage.Navigation.PushAsync(new HienThiLanKham(id));
        }

        private void OnRefreshing(object sender, EventArgs e)
        {
            var listView = sender as ListView;
            listView.EndRefresh();
        }
    }
}