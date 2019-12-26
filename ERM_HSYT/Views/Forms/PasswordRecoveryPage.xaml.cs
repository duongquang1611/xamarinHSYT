using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class PasswordRecoveryPage : ContentPage
    {
        public PasswordRecoveryPage()
        {
            InitializeComponent();
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}