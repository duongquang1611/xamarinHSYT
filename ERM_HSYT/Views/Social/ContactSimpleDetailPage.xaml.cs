using System;

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ContactSimpleDetailPage : ContentPage
    {
        public ContactSimpleDetailPage()
        {
            InitializeComponent();

			BindingContext = new ContactSimpleDetailViewModel();
        }

        private async void OnEdit(object sender, EventArgs e)
        {
            await DisplayAlert("Edit tapped", "Navigate to the edit contact page.", Resx.AppResources.StringOK);
        }

        private async void OnClose(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}