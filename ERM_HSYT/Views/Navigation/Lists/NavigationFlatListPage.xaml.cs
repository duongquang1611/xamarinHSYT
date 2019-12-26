using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NavigationFlatListPage : ContentPage
    {
        public NavigationFlatListPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}

