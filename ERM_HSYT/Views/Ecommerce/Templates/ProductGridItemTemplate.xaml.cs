using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ProductGridItemTemplate : ContentView
    {
        public ProductGridItemTemplate()
        {
            InitializeComponent();
        }

        private async void OnProductTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            var productPage = new ProductItemViewPage(BindingContext as ProductData);

            await Navigation.PushAsync(productPage);
#endif
        }
    }
}