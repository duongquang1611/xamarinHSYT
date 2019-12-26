using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class MoviesMainPage : ContentPage
    {
        public MoviesMainPage()
        {
            InitializeComponent();

            BindingContext = new MoviesMainViewModel();
        }

        private async void OnFeatured(object sender, EventArgs e)
        {
#if !NAVIGATION
            var page = new MoviesNavigationPage(
                new FeaturedMoviesPage(((MoviesMainViewModel)BindingContext).Featured));

            GrialNavigationPage.SetIsBarTransparent(page, true);
            await Navigation.PushModalAsync(page);
#endif
        }
    }
}
