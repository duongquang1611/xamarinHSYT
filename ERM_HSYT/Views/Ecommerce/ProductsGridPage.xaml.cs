using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ProductsGridPage : ContentPage
    {
        public ProductsGridPage()
        {
            InitializeComponent();

            BindingContext = new ProductsCatalogViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }

        private async void OnBannerTapped(object sender, EventArgs e)
        {
            const uint AnimationDurantion = 250;

            var visualElement = (VisualElement)sender;

            await Task.WhenAll(
                visualElement.FadeTo(0, AnimationDurantion, Easing.CubicIn),
                visualElement.ScaleTo(0, AnimationDurantion, Easing.CubicInOut)
            );

            visualElement.IsVisible = false;
        }
    }
}