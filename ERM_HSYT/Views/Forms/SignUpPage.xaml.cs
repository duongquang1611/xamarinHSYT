using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnLoginTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            await Navigation.PushAsync(new LoginPage());
#endif
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}