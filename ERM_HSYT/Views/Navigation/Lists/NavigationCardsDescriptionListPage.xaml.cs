using System;
using System.Collections.Generic;

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NavigationCardsDescriptionListPage : ContentPage
    {
        public NavigationCardsDescriptionListPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}
