using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class IconsDashboardPage : ContentPage
    {
        public IconsDashboardPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}