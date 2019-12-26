using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NavigationListWithIconsPage : ContentPage
    {
        public NavigationListWithIconsPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}

