using System;
using System.Collections.Generic;

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class VideoCarouselHighlightsPage : ContentPage
    {
        public VideoCarouselHighlightsPage()
        {
            InitializeComponent();

            BindingContext = new VideoCarouselHighlightsViewModel();
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

    }
}
