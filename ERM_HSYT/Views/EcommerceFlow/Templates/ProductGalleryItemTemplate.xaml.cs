using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT 
{
    public partial class ProductGalleryItemTemplate : ContentView
    {
        public ProductGalleryItemTemplate()
        {
            InitializeComponent();
        }

        private async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
#if !NAVIGATION
            var productView = new ProductDetailPage(
                ((VisualElement)sender).BindingContext as FlowProductData);

            await Navigation.PushAsync(productView);
#endif
        }
    }
}
