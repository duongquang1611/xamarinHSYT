using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        public async void OnWhatsNew(object sender, EventArgs e)
        {
#if !NAVIGATION
            await Navigation.PushAsync(new WalkthroughImagePage());
#endif
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}