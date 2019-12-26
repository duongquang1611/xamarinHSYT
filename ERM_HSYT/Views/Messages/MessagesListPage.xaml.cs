using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class MessagesListPage : ContentPage
    {
        public MessagesListPage()
        {
            InitializeComponent();

            BindingContext = new MessagesListViewModel();
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
    }
}

