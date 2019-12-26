using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SocialVariantPage : ContentPage
    {
        public SocialVariantPage()
        {
            InitializeComponent();

            BindingContext = new SocialViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }

        private async void OnAvatarTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            await Navigation.PushAsync(new ProfilePage());
#endif
        }
    }
}