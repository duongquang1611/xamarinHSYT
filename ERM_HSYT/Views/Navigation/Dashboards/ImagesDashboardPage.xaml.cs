using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ImagesDashboardPage : ContentPage
    {
        public ImagesDashboardPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}