using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class EmptyStatePage : ContentPage
    {
        public EmptyStatePage()
        {
            InitializeComponent();
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}