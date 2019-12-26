using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SocialPage : ContentPage
    {
        public SocialPage()
        {
            InitializeComponent();

            BindingContext = new SocialViewModel();
        }

        private async void OnAvatarTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            await Navigation.PushAsync(new ProfilePage());
#endif
        }
    }
}